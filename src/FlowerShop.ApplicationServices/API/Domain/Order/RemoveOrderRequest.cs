using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Order;

public class RemoveOrderRequest : IRequest<RemoveOrderResponse>
{
    public required int OrderId;
}