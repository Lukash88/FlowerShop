using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class GetUserAddressRequest : IRequest<GetUserAddressResponse>
    {
        public string Email { get; init; }
    }
}