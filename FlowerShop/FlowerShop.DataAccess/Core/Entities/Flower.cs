using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class Flower : EntityBase
    {
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public int? LengthInCm { get; set; }
        public FlowerColour Colour { get; set; }
        public int StockLevel { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

        public List<Bouquet> Bouquets { get; set; } = new();
    }
}