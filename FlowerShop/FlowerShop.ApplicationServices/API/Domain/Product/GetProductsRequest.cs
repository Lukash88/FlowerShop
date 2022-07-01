namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;
    using Sieve.Models;

    public class GetProductsRequest : IRequest<PagedResponse<GetProductsResponse>>
    {
        public string Name { get; init; }
        public SieveModel SieveModel { get; }

        public GetProductsRequest(SieveModel sieveModel)
        {
            SieveModel = sieveModel;
        }
    }
}