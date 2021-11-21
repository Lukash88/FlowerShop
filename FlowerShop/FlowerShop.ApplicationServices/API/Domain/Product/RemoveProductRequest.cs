namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;

    public class RemoveProductRequest : IRequest<RemoveProductResponse>
    {
        public int ProductId { get; init; }
    }
}