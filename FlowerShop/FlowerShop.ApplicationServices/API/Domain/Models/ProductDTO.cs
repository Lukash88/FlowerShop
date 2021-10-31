using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public object LongDescription { get; internal set; }
        public string Category { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
