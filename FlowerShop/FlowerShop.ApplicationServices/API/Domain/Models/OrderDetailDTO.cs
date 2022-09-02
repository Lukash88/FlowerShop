namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System.Collections.Generic;

    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }

        public int OrderId { get; set; }
        public OrderDTO OrderDTO { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<BouquetDTO> Bouquets { get; set; } = new();
        public List<DecorationDTO> Decorations { get; set; } = new();
    }
}