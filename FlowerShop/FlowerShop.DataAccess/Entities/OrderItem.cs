using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class OrderItem : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetails { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Bouquet> Bouquets { get; set; } = new List<Bouquet>();

        public List<Decoration> Decorations { get; set; } = new List<Decoration>();
    }
}