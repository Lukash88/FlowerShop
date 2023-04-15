using FlowerShop.ApplicationServices.API.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Basket
{
    public class UpdateBasketRequest : IRequest<UpdateBasketResponse>
    {
        public string BasketId;
        public List<BasketItemDto> Items { get; set; }
    }
}