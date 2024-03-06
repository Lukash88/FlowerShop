using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class FlowerDto : ProductDto
    {        
        public FlowerType FlowerType { get; init; }
        public int? LengthInCm { get; init; }
        public FlowerColor Color { get; init; }
    }
}