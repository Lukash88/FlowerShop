namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate
{
    public class DeliveryMethod : EntityBase
    {
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}