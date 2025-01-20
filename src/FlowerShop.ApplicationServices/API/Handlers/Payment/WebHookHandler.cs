using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Payment;
using MediatR;
using Microsoft.Extensions.Logging;
using Stripe;

namespace FlowerShop.ApplicationServices.API.Handlers.Payment;

public sealed class WebHookHandler(IPaymentService paymentService, ILogger<WebHookHandler> logger)
    : IRequestHandler<StripeWebhookRequest, StripeWebhookResponse>
{
    public async Task<StripeWebhookResponse> Handle(StripeWebhookRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var stripeEvent = paymentService.ConstructStripeEvent(request.Json, request.StripeSignature);
            if (stripeEvent.Data.Object is not PaymentIntent intent)
            {
                return new StripeWebhookResponse
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Invalid payment data.")
                };
            }

            var orderWithPaymentIntentSucceeded = await paymentService.HandlePaymentIntentSucceeded(intent);
            var response = new StripeWebhookResponse
            {
                Data = orderWithPaymentIntentSucceeded
            };

            return response;
        }
        catch (StripeException e)
        {
            logger.LogError(e, "Stripe webhook error occured");

            return new StripeWebhookResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Webhook error.")
            };
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occured");

            return new StripeWebhookResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - An unexpected error occured")
            };
        }
    }
}