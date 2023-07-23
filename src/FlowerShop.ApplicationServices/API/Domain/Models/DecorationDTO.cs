using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class DecorationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Role { get; set; }
        public bool IsAvailable { get; set; }
        public decimal? Price { get; set; }
        public int StockLevel { get; set; }

       // public List<OrderDetailDto> OrderDetails { get; set; } = new();
    }
}