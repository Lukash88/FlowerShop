using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class Bouquet : EntityBase
    {
        public Occasion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new();
        public List<Flower> Flowers { get; set; } = new(); 
    }
}