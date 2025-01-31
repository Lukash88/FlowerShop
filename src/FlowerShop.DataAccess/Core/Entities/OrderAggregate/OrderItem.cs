using FlowerShop.DataAccess.Core.Entities.Interfaces;

namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public class OrderItem : IEntityBase
{  
    public int Id { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public ProductItemOrdered ItemOrdered { get; init; } = null!;
}