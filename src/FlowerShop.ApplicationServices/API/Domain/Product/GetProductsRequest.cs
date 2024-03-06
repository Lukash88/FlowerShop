using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}