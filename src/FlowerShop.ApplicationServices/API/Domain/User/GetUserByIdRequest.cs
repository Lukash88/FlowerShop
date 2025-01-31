using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
{
    public required int UserId { get; init; }
}