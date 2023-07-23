using System;
using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public string Invoice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
        public int Quantity { get; set; }
        public decimal? Sum { get; set; }

        public List<ReservationDto> Reservations { get; set; } = new();
        public List<OrderDetailDto> OrderDetails { get; set; } = new();
    }
}