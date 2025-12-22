using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.DataAccess.Core.Entities;

public sealed class ShoppingCart
{
    public required string Id { get; init; }
    public List<CartItem> Items { get; init; } = [];
    public int? DeliveryMethodId { get; init; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
    public AppCoupon? Coupon { get; init; }
}