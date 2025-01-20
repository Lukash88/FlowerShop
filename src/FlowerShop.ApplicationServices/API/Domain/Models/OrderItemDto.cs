namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class OrderItemDto
{
    public required int ProductId { get; init; }
    public required decimal Price { get; init; }
    public required string ProductName { get; init; }
    public required string ImageUrl { get; init; }
    public required int Quantity { get; init; }
}