using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities;

public class CartItem
{
    public int ProductId { get; init; }
    public required string ProductName { get; init; }
    public required string ShortDescription { get; init; }
    public decimal Price { get; set; }
    public int Quantity { get; init; }
    public required string ImageUrl { get; init; }
    public required Category Category { get; init; }
}