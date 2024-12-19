using System.Collections.Generic;
using FlowerShop.ApplicationServices.API.Domain.Models;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Basket
{
    public class UpdateBasketRequest : IRequest<UpdateBasketResponse>
    {
        public string? BasketId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new();
        public int? DeliveryMethodId { get; init; }
        public string? ClientSecret { get; init; }
        public string? PaymentIntentId { get; init; }
    }
}