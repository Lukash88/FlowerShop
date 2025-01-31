using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities;

public class BasketItem : IEntityBase
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string ShortDescription { get; init; }
    public decimal Price { get; set; }
    public int Quantity { get; init; }
    public required string ImageUrl { get; init; }
    public required Category Category { get; init; }
}