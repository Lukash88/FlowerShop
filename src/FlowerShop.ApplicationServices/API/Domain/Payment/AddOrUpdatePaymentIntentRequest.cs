using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Payment;

public sealed class AddOrUpdatePaymentIntentRequest : IRequest<AddOrUpdatePaymentIntentResponse>
{
    public string CartId { get; set; } = string.Empty;
}