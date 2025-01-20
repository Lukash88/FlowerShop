using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class DecorationDto : ProductDto
{
    public required DecorationRole Role { get; init; }
}