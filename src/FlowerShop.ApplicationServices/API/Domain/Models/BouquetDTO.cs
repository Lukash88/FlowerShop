using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System.Collections.Generic;

    public class BouquetDto
    {
        public int Id { get; set; }
        public Occasion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; } 
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }
        public List<FlowerDto> Flowers { get; set; } = new();
        public List<OrderDetailDto> OrderDetails { get; set; } = new();
    }
}