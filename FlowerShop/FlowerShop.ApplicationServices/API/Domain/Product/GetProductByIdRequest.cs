namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    using MediatR;

    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int ProductId { get; init; }
    }
}