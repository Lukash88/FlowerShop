using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }

        public int OrderId { get; set; }
        public OrderDto OrderDto { get; set; }
        public List<ProductDto> Products { get; set; } = new();
        public List<BouquetDto> Bouquets { get; set; } = new();
        public List<DecorationDto> Decorations { get; set; } = new();
    }
}