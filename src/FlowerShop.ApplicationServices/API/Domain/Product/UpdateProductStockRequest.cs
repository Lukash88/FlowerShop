using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Product;

public sealed class UpdateProductStockRequest : IRequest<UpdateProductStockResponse>
{
    public int ProductId { get; set; }
    public int NewQuantity { get; set; }
}