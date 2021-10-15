using FlowerShop.DataAccess.Enums;
using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class Flower : EntityBase
    {
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public byte LengthInCm { get; set; }
        public FlowerColour Colour { get; set; }

        public List<Bouquet> Bouquets { get; set; } = new List<Bouquet>();
    }
}