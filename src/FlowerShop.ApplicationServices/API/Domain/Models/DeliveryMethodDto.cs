﻿namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class DeliveryMethodDto
    {
        public string ShortName { get; init; }
        public string DeliveryTime { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}