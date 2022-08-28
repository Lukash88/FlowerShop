namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;
    using System.Collections.Generic;

    public class FlowerDTO
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public int LengthInCm { get; set; }
        public FlowerColour Colour { get; set; }
        public int StockLevel { get; set; }
        public decimal? Price { get; set; }
        public List<BouquetDTO> Bouquets { get; set; } = new List<BouquetDTO>();
    }
}