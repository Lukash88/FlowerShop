using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Order;

public class GetOrdersForUserRequest : IRequest<GetOrdersResponse>
{
    public required string Email { get; init; }
    public required SieveModel SieveModel { get; init; }
}