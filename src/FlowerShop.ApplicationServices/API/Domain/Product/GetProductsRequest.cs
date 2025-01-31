using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Product;

public class GetProductsRequest : IRequest<GetProductsResponse>
{
    public required SieveModel SieveModel { get; init; }
}