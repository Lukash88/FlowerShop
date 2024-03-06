using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public string Email { get; init; }
    }
}