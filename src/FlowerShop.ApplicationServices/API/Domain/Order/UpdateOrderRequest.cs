﻿using FlowerShop.ApplicationServices.API.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse>
    {
        public int OrderId { get; set; }
        public string BuyerEmail { get; init; }
        public DateTime? CreatedAt { get; init; }
        public Address ShipToAddress { get; init; }
        public int DeliveryMethodId { get; init; }
        public decimal Subtotal { get; init; }
        public string Status { get; init; }
        public string Invoice { get; init; }
        public string? PaymentIntentId { get; init; }
        public List<OrderItemDto> OrderItems { get; init; }
        public List<ReservationDto> Reservations { get; init; }
    }
}