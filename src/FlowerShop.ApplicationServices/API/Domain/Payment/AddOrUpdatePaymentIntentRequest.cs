using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Payment;

public sealed class AddOrUpdatePaymentIntentRequest : IRequest<AddOrUpdatePaymentIntentResponse>
{
    public string BasketId { get; set; } = string.Empty;
}