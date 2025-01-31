using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class BouquetDto : ProductDto
{
    public required Occasion Occasion { get; init; }
    public required TypeOfFlowerArrangement TypeOfArrangement { get; init; }
    public required DecorationWay DecorationWay { get; init; }
}