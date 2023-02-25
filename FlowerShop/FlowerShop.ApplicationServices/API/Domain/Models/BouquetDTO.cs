using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System.Collections.Generic;

    public class BouquetDTO
    {
        public int Id { get; set; }
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; } 
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }
        public List<FlowerDTO> Flowers { get; set; } = new();
        public List<OrderDetailDTO> OrderDetails { get; set; } = new();
    }
}