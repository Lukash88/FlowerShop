﻿using System.Collections.Generic;

namespace FlowerShop.DataAccess.Core.Entities
{
    public class OrderDetail : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<Product> Products { get; set; } = new();
        public List<Bouquet> Bouquets { get; set; } = new();
        public List<Decoration> Decorations { get; set; } = new();
    }
}