namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System.Collections.Generic;

    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public object LongDescription { get; internal set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public int StockLevel { get; set; }

        public List<string> OrderItems { get; set; } = new List<string>();
        // public List<OrderDTO> OrderItems { get; set; } = new List<OrderDTO>();
    }
}