using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Cart;

public class GetCartByIdRequest : IRequest<GetCartByIdResponse>
{
    public required string CartId { get; init; }
}