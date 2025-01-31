using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.DataAccess.Core.Entities;

public class Decoration : Product
{
    public required DecorationRole Role { get; init; }
}