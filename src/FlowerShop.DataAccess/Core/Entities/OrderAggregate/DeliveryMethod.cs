using FlowerShop.DataAccess.Core.Entities.Interfaces;

namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public class DeliveryMethod : IEntityBase
{
    public int Id { get; init; }
    public required string ShortName { get; init; }
    public required string DeliveryTime { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
}