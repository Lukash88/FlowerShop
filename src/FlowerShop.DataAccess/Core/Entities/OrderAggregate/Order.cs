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
            DeliveryMethod deliveryMethod, decimal subtotal, string invoice)
        {
            OrderItems = orderItems;
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }

        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public decimal Subtotal { get; set; }
        public OrderState OrderState { get; set; } = OrderState.Pending;
        public string Invoice { get; set; }
        public string PaymentIntentId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();      
        

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}