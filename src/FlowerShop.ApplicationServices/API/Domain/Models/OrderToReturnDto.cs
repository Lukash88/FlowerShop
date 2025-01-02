using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class OrderToReturnDto
    {
        public int Id { get; init; }
        public string BuyerEmail { get; init; }
        public DateTime CreatedAt { get; init; }
        public Address ShipToAddress { get; init; }
        public string DeliveryMethod { get; init; }
        public List<OrderItemDto> OrderItems { get; set; } = new();
        public decimal Subtotal { get; init; }
        public decimal ShippingPrice { get; init; }
        public decimal Total { get; init; }
        public string Invoice { get; init; }
        public string Status { get; init; }
    }
}