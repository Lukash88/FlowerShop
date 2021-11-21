namespace FlowerShop.DataAccess.Entities
{
    using System.Collections.Generic;

    public class OrderDetail : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Bouquet> Bouquets { get; set; } = new List<Bouquet>();

        public List<Decoration> Decorations { get; set; } = new List<Decoration>();
    }
}