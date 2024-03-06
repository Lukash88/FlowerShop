using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class CustomerBasketDto
    {
        public string Id { get; init; }
        public List<BasketItemDto> Items { get; init; } = new();
    }
}