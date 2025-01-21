using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public class Order : IEntityBase
{
    public int Id { get; init; }
    public required string BuyerEmail { get; init; }
    public DateTime CreatedAt { get; init; }
    public ShippingAddress ShippingAddress { get; init; } = null!;
    public DeliveryMethod DeliveryMethod { get; set; } = null!;
    public decimal Subtotal { get; init; }
    public OrderState OrderState { get; set; }
    public string Invoice { get; set; } = String.Empty;
    public required string PaymentIntentId { get; init; }

    public List<OrderItem> OrderItems { get; init; } = [];
    public List<Reservation> Reservations { get; init; } = [];


    public decimal GetTotal()
    {
        return Subtotal + DeliveryMethod.Price;
    }
}