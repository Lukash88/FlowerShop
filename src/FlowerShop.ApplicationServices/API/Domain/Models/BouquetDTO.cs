using FlowerShop.DataAccess.Core.Enums;
using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class BouquetDto : ProductDto
    {
        public Occasion Occasion { get; init; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; init; }
        public DecorationWay DecorationWay { get; init; }
        public List<FlowerDto> Flowers { get; init; } = new();
    }
}