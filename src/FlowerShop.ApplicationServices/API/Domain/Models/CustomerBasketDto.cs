using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } = new();
    }
}