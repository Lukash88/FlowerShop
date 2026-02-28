namespace FlowerShop.ApplicationServices.API.Domain.Models;

public sealed class CartItemDto
{
    public int ProductId { get; init; }
    public required string ProductName { get; init; }
    public required string ShortDescription { get; init; }
    public required decimal Price { get; init; }
    public required int Quantity { get; init; }
    public required string ImageUrl { get; init; }
    public required string Category { get; init; }
}