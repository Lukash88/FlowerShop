namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System;

    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderState OrderState { get; set; }
    }
}
