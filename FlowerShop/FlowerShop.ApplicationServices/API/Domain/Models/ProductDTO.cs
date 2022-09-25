namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System.Collections.Generic;
    using FlowerShop.DataAccess.Enums;

    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public object LongDescription { get; internal set; }
        public Category Category { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockLevel { get; set; }
                
        public List<OrderDetailDTO> OrderDetails { get; set; } = new();
    }
}