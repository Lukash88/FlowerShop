using System.Collections.Generic;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class Bouquet : Product
    {
        public Occasion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public DecorationWay DecorationWay { get; set; }

        public List<Flower> Flowers { get; set; } = new(); 
    }
}