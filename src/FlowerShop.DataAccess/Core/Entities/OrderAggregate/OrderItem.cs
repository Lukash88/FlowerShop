using FlowerShop.DataAccess.Core.Entities.Interfaces;

namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate
{
    public class OrderItem : IEntityBase
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductItemOrdered ItemOrdered { get; set; }
    }
}