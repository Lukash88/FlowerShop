using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int OrderDetailId { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public List<BouquetDTO> Bouquets { get; set; } = new List<BouquetDTO>();
        public List<DecorationDTO> Decorations { get; set; } = new List<DecorationDTO>();
    }
}
