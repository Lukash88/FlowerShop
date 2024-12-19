using FlowerShop.DataAccess.Core.Entities.Interfaces;

namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate
{
    public class DeliveryMethod : IEntityBase
    {
        public int Id { get; init; }
        public string ShortName { get; init; }
        public string DeliveryTime { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}