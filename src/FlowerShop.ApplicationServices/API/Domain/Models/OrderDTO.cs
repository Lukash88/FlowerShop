namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class OrderDto
    {
        public string BasketId { get; init; }
        public int DeliveryMethodId { get; init; }
        public AddressDto ShippingAddress { get; init; }
    }
}