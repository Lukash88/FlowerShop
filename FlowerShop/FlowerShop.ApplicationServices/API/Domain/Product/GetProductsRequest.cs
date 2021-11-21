namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;

    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string Name { get; init; }
    }
}