using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class BouquetDto : ProductDto
    {
        public Occasion Occasion { get; init; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; init; }
        public DecorationWay DecorationWay { get; init; }
    }
}