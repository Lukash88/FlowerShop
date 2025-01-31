using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class GetUserAddressRequest : IRequest<GetUserAddressResponse>
{
    public required string Email { get; init; }
}