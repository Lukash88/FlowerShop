using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class FlowerDto
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public int LengthInCm { get; set; }
        public FlowerColor Color { get; set; }
        public int StockLevel { get; set; }
        public decimal? Price { get; set; }
        //public List<BouquetDto> Bouquets { get; set; } = new();
    }
}