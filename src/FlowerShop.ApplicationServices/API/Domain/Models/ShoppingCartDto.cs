using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class ShoppingCartDto
{
    public string? Id { get; init; }
    public List<CartItemDto> Items { get; init; } = [];
    public int? DeliveryMethodId { get; init; }
    public string? ClientSecret { get; init; }
    public string? PaymentIntentId { get; init; }
    public AppCoupon? Coupon { get; init; }
}