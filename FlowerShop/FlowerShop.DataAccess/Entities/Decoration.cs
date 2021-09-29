using FlowerShop.DataAccess.Enums;
using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class Decoration : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Roles { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }

        public List<OrderItem> OrderItrems { get; set; } = new List<OrderItem>();
    }
}