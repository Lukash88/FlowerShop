namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class OrderDto
{
    public required string BasketId { get; init; }
    public required int DeliveryMethodId { get; init; }
    public required AddressDto ShippingAddress { get; init; }
}