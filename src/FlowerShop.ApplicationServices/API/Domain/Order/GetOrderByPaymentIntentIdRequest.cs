using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Order;

public sealed class GetOrderByPaymentIntentIdRequest : IRequest<GetOrderByPaymentIntentIdResponse>
{
    public required string Id { get; init; }
}