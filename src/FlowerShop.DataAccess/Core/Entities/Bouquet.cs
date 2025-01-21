using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities;

public class Bouquet : Product
{
    public required Occasion Occasion { get; init; }
    public required TypeOfFlowerArrangement TypeOfArrangement { get; init; }
    public required DecorationWay DecorationWay { get; init; }
}