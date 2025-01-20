namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class ProductDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string ShortDescription { get; init; }
    public required string LongDescription { get; init; }
    public required string Category { get; init; }
    public required decimal Price { get; init; }
    public required string ImageUrl { get; init; }
    public required string ImageThumbnailUrl { get; init; }
    public int StockLevel { get; init; }
}