using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using ReservationEntity = FlowerShop.DataAccess.Core.Entities.Reservation;

namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse>
    {
        public int OrderId { get; set; }
        public string BasketId { get; set; }
        public string BuyerEmail { get; init; }
        public DateTime? CreatedAt { get; init; }
        public Address ShipToAddress { get; init; }
        public int DeliveryMethodId { get; init; }
        public decimal Subtotal { get; set; }
        public string Status { get; init; }
        public string Invoice { get; init; }
        public string PaymentIntentId { get; init; }
        public List<OrderItemDto> OrderItems { get; set; }
        public List<ReservationEntity> Reservations { get; init; }
    }
}