using FlowerShop.DataAccess.Enums;
using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class Bouquet : EntityBase
    {
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public int Quantity { get; set; }
        public DecorationWay DecorationWay { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public List<Flower> Flowers { get; set; } = new List<Flower>(); 
    }
}
