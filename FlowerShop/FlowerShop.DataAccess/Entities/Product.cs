namespace FlowerShop.DataAccess.Entities
{
    using System.Collections.Generic;

    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public int StockLevel { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}