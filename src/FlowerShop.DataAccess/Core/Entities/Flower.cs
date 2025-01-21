using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities;

public class Flower : Product
{
    public required FlowerType FlowerType { get; init; }
    public int? LengthInCm { get; init; }
    public required FlowerColor Color { get; init; }
}