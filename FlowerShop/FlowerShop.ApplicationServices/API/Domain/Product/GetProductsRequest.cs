namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;
    using Sieve.Models;

    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}