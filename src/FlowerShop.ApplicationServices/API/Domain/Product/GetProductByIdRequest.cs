using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int ProductId { get; init; }
    }
}