﻿using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.DeliveryMethod
{
    public class AddDeliveryMethodRequest : IRequest<AddDeliveryMethodResponse>
    {
        public string ShortName { get; init; }
        public string DeliveryTime { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}