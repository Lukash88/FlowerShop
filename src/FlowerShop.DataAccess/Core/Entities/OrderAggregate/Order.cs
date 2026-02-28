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
    public PaymentSummary PaymentSummary { get; init; } = null!;
    public decimal Subtotal { get; init; }
    public decimal Discount { get; init; }
    public OrderState OrderState { get; init; }
    public string Invoice { get; set; } = string.Empty;
    public required string PaymentIntentId { get; init; }

    public List<OrderItem> OrderItems { get; init; } = [];
    public List<Reservation> Reservations { get; init; } = [];


    public decimal GetTotal()
    {
        return Subtotal - Discount + DeliveryMethod.Price;
    }
}