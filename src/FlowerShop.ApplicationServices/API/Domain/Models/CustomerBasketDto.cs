using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class CustomerBasketDto
    {
        public string Id { get; init; }
        public List<BasketItemDto> Items { get; set; } = new();
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; init; }
        public string PaymentIntentId { get; init; }
    }
}