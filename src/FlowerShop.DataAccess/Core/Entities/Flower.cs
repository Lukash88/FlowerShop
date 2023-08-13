using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class Flower : Product
    {
        public FlowerType FlowerType { get; set; }
        public int? LengthInCm { get; set; }
        public FlowerColor Color { get; set; }

        public List<Bouquet> Bouquets { get; set; } = new();
    }
}