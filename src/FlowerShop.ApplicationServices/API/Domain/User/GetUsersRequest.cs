using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class GetUsersRequest : IRequest<GetUsersResponse>
{
    public required SieveModel SieveModel { get; init; }
}