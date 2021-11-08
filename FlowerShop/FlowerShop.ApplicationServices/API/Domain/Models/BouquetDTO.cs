namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System.Collections.Generic;

    public class BouquetDTO
    {
        public int Id { get; set; }
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public int Quantity { get; set; }
        public DecorationWay DecorationWay { get; set; }

        public List<string> Flowers { get; set; } = new List<string>();
        public List<string> OrderItems { get; set; } = new List<string>();
        // public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
        // public List<FlowerDTO> Flowers { get; set; } = new List<FlowerDTO>();
    }
}

