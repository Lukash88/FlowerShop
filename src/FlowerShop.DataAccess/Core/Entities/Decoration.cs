using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class Decoration : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Role { get; set; }
        public bool IsAvailable { get; set; }
        public decimal? Price { get; set; }
        public int StockLevel { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}