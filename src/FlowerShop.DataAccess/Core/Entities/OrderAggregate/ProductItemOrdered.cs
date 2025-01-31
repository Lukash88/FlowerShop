namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public class ProductItemOrdered
{
    public int ProductItemId { get; init; }
    public required string ProductName { get; init; }
    public required string ImageUrl { get; init; }
}