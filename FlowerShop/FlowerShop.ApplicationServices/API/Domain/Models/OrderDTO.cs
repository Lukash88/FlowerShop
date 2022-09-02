namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System;
    using System.Collections.Generic;

    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public string Invoice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
        public int Quantity { get; set; }
        public decimal? Sum { get; set; }

        public List<ReservationDTO> Reservations { get; set; } = new List<ReservationDTO>();
        public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}