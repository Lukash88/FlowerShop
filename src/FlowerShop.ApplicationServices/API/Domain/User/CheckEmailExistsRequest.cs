using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class CheckEmailExistsRequest : IRequest<CheckEmailExistsResponse>
{
    public required string EmailToCheck { get; init; }
}