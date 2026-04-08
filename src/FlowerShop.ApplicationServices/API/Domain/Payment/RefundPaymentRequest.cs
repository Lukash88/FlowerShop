using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Payment;

public sealed class RefundPaymentForOrderRequest : IRequest<RefundPaymentForOrderResponse>
{
    public int Id { get; init; }
}