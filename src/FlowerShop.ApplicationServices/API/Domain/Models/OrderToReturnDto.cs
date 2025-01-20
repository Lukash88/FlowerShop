using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class OrderToReturnDto
{
    public int Id { get; init; }
    public required string BuyerEmail { get; init; }
    public DateTime CreatedAt { get; init; }
    public required ShippingAddress ShippingAddress { get; init; }
    public required string DeliveryMethod { get; init; }
    public required List<OrderItemDto> OrderItems { get; init; } = [];
    public required decimal Subtotal { get; init; }
    public required decimal ShippingPrice { get; init; }
    public required decimal Total { get; init; }
    public string? Invoice { get; init; }
    public required string Status { get; init; }
}