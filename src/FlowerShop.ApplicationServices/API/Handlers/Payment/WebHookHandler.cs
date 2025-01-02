using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Payment;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;

namespace FlowerShop.ApplicationServices.API.Handlers.Payment
{
    public sealed class WebHookHandler : IRequestHandler<StripeWebhookRequest, StripeWebhookResponse>
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<WebHookHandler> _logger;

        public WebHookHandler(IPaymentService paymentService, ILogger<WebHookHandler> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        public async Task<StripeWebhookResponse> Handle(StripeWebhookRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var stripeEvent = _paymentService.ConstructStripeEvent(request.Json, request.StripeSignature);
                if (stripeEvent.Data.Object is not PaymentIntent intent)
                {
                    return new StripeWebhookResponse()
                    {
                        Error = new ErrorModel(ErrorType.BadRequest + " - Invalid payment data.")
                    };
                }

                var orderWithPaymentIntentSucceeded = await _paymentService.HandlePaymentIntentSucceeded(intent);
                var response = new StripeWebhookResponse
                {
                    Data = orderWithPaymentIntentSucceeded
                };

                return response;
            }
            catch (StripeException e)
            {
                _logger.LogError(e, "Stripe webhook error occured");

                return new StripeWebhookResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Webhook error.")
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An unexpected error occured");

                return new StripeWebhookResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - An unexpected error occured")
                };
            }
        }
    }
}