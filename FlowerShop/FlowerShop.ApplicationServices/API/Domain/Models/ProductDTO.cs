using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System.Collections.Generic;

    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Category Category { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockLevel { get; set; }

        public IList<OrderDetailDTO> OrderDetails { get; set; }
    }
}