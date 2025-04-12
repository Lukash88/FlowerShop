using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Payment;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.Payment;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Payment;

public sealed class AddOrUpdatePaymentIntentHandler(IPaymentService paymentService)
    : IRequestHandler<AddOrUpdatePaymentIntentRequest, AddOrUpdatePaymentIntentResponse>
{
    public async Task<AddOrUpdatePaymentIntentResponse> Handle(AddOrUpdatePaymentIntentRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var cart = await paymentService.CreateOrUpdatePaymentIntent(request.CartId);

            return new AddOrUpdatePaymentIntentResponse
            {
                Data = cart
            };
        }
        catch (Exception ex)
        {
            // TODO: Log the exception
            return new AddOrUpdatePaymentIntentResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest + " - Problem with your cart. " + ex.Message)
            };
        }
    }
}