using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Product;

public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
{
    public required int ProductId { get; init; }
}