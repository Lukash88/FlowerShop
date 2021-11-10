namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System.Collections.Generic;

    public class DecorationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Role { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public List<string> OrderItems { get; set; } = new List<string>();
        // public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
