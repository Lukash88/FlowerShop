using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class OrderDto
{
    public int Id { get; init;}
    public required string CartId { get; init; }
    public required int DeliveryMethodId { get; init; }
    public required AddressDto ShippingAddress { get; init; }
    public required PaymentSummary PaymentSummary { get; init; }
}