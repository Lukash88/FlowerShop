using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class BasketItem : IEntityBase
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string ShortDescription { get; init; }
        public decimal Price { get; set; }
        public int Quantity { get; init; }
        public string ImageUrl { get; init; }
        public Category Category { get; init; }
    }
}