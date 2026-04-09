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
        logger.LogInformation("Webhook Handler started");

        try
        {
            var stripeEvent = paymentService.ConstructStripeEvent(request.Json, request.StripeSignature);
            logger.LogInformation("Stripe event constructed. Type: {EventType}", stripeEvent.Type);

            var order = await paymentService.HandleStripeEvent(stripeEvent);

            return new StripeWebhookResponse
            {
                Data = order
            };
        }
        catch (StripeException e)
        {
            logger.LogError(e, "Stripe webhook error: {Message}", e.Message);

            return new StripeWebhookResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Webhook error: " + e.Message)
            };
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unexpected error in webhook handler: {Message}", e.Message);

            return new StripeWebhookResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - " + e.Message)
            };
        }
    }
}