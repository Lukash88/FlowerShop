namespace FlowerShop.DataAccess.Core.Entities;

public sealed class CustomerBasket
{
    public required string Id { get; init; }
    public List<BasketItem> Items { get; init; } = [];
    public int? DeliveryMethodId { get; init; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
}