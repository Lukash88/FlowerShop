using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Payment;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlowerShop.ApplicationServices.API.Handlers.Payment;

public sealed class AddOrUpdatePaymentIntentHandler(
    IPaymentService paymentService,
    ILogger<AddOrUpdatePaymentIntentHandler> logger)
    : IRequestHandler<AddOrUpdatePaymentIntentRequest, AddOrUpdatePaymentIntentResponse>
{
    public async Task<AddOrUpdatePaymentIntentResponse> Handle(AddOrUpdatePaymentIntentRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("AddOrUpdatePaymentIntentHandler started for CartId: {CartId}", request.CartId);

        try
        {
            logger.LogInformation("Creating or updating payment intent...");
            var cart = await paymentService.CreateOrUpdatePaymentIntent(request.CartId);

            logger.LogInformation("Payment intent processed successfully. CartId: {CartId},"
                +"PaymentIntentId: {PaymentIntentId}, ClientSecret: {ClientSecretPrefix}...",
                cart.Id,
                cart.PaymentIntentId,
                cart.ClientSecret?[..Math.Min(20, cart.ClientSecret?.Length ?? 0)] ?? "null");

            return new AddOrUpdatePaymentIntentResponse
            {
                Data = cart
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating/updating payment intent for CartId {CartId}: {Message}\nStackTrace: {StackTrace}",
                request.CartId, ex.Message, ex.StackTrace);

            return new AddOrUpdatePaymentIntentResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem with your cart. " + ex.Message)
            };
        }
    }
}