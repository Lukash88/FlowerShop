using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class GetCurrentUserRequest : IRequest<GetCurrentUserResponse>
{
    public required string CurrentUserEmail { get; init; }
}