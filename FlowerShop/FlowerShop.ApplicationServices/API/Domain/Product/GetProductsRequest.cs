namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;
    using Sieve.Models;

    //public class GetProductsRequest : IRequest<GetProductsResponse>
    public class GetProductsRequest : IRequest<PagedResponse<GetProductsResponse>>
    {
        public SieveModel SieveModel { get; init; }
    }
}