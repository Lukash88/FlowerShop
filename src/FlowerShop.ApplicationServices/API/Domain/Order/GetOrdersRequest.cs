using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Order;

public class GetOrdersRequest : IRequest<GetOrdersResponse>
{
    public required SieveModel SieveModel { get; init; }
}