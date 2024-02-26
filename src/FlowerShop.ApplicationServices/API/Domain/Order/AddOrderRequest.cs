using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using MediatR;
using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    public class AddOrderRequest : IRequest<AddOrderResponse>
    {
        public string BasketId { get; init; }
        public string BuyerEmail { get; set; }
        public Address ShipToAddress { get; init; }
        public List<OrderItemDto> Items { get; init; }
        public int DeliveryMethodId { get; init; }
        public decimal Subtotal { get; init; }
        public string Status { get; init; }
        public string Invoice { get; init; }
    }
}