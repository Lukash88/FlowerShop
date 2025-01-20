using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Basket;

public class RemoveBasketRequest : IRequest<RemoveBasketResponse>
{
    public required string BasketId { get; init; }
}