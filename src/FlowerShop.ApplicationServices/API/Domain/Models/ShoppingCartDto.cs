using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class ShoppingCartDto
{
    public string? Id { get; init; }
    public List<CartItemDto> Items { get; set; } = [];
    public int? DeliveryMethodId { get; set; }
    public string? ClientSecret { get; init; }
    public string? PaymentIntentId { get; init; }
}