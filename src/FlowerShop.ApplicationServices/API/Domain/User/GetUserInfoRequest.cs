using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class GetUserInfoRequest : IRequest<GetUserInfoResponse>
{
    public required string Email { get; init; } = string.Empty;
}