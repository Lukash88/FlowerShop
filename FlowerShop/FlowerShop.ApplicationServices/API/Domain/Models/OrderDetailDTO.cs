namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using System.Collections.Generic;

    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }

        //public List<string> Products { get; set; } = new List<string>();
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();

        //public List<string> Bouquets { get; set; } = new List<string>();
        public List<BouquetDTO> Bouquets { get; set; } = new List<BouquetDTO>();

        //public List<string> Decorations { get; set; } = new List<string>();
        public List<DecorationDTO> Decorations { get; set; } = new List<DecorationDTO>();
    }
}