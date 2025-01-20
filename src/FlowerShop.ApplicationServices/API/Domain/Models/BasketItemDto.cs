namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class BasketItemDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string ShortDescription { get; init; }
    public required decimal Price { get; init; }
    public required int Quantity { get; init; }
    public required string ImageUrl { get; init; }
    public required string Category { get; init; }
}