using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class FlowerDto : ProductDto
{        
    public required FlowerType FlowerType { get; init; }
    public int? LengthInCm { get; init; }
    public required FlowerColor Color { get; init; }
}