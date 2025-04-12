using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Cart;

public class RemoveCartRequest : IRequest<RemoveCartResponse>
{
    public required string CartId { get; init; }
}