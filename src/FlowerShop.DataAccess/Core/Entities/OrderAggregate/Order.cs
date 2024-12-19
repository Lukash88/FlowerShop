using System;
using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Entities.Interfaces;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate
{
    public class Order : IEntityBase
    {
        public Order()
        {
        }

        public Order(List<OrderItem> orderItems, string buyerEmail, Address shipToAddress,
            DeliveryMethod deliveryMethod, decimal subtotal,
            string invoice, string paymentIntentId)
        {
            OrderItems = orderItems;
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;
        }

        public int Id { get; init; }
        public string BuyerEmail { get; set; }
        public DateTime CreatedAt { get; init; }
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public decimal Subtotal { get; set; }
        public OrderState OrderState { get; set; }
        public string Invoice { get; set; }
        public string PaymentIntentId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
        public List<Reservation> Reservations { get; init; } = new();


        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}