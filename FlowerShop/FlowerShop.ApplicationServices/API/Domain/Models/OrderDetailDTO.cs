namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System;
    using System.Collections.Generic;

    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
        public int ReservationId { get; set; }
        //public List<string> OrderItems = new List<string>();
        //public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
