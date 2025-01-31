using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Basket;

public class GetBasketByIdRequest : IRequest<GetBasketByIdResponse>
{
    public required string BasketId { get; init; }
}