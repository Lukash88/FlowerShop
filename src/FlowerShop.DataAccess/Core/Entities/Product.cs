using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities;

public abstract class Product : IEntityBase
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string ShortDescription { get; init; }
    public required string LongDescription { get; init; }
    public Category Category { get; init; }
    public decimal Price { get; init; }
    public required string ImageUrl { get; init; }
    public required string ImageThumbnailUrl { get; init; }
    public int StockLevel { get; init; }
}