using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class LoginAppUserRequest : IRequest<LoginAppUserResponse>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}