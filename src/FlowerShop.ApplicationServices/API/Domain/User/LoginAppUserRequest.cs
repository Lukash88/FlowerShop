using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class LoginAppUserRequest : IRequest<LoginAppUserResponse>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}