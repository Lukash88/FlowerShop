using FlowerShop.DataAccess.Enums;
using System;
using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class OrderDetail : EntityBase
    {
        public int ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderState OrderState { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}