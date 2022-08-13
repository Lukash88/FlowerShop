namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System.Collections.Generic;

    public class BouquetDTO
    {
        public int Id { get; set; }
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; } 
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }

        //public List<string> FlowerNames { get; set; } = new List<string>();
        //public List<string> Flowers { get; set; } = new List<string>();
        public List<FlowerDTO> Flowers { get; set; } = new List<FlowerDTO>();

        //public List<string> OrderDetails { get; set; } = new List<string>();
        public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}