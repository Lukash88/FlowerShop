using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    public class AddFlowerRequest : IRequest<AddFlowerResponse>
    {
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public int LengthInCm { get; set; }
        public FlowerColor Color { get; set; }
        public int StockLevel { get; set; }
        public decimal? Price { get; set; }
    }
} 