using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Flower;

public class UpdateFlowerRequest : UpdateProductRequest, IRequest<UpdateFlowerResponse>
{
    public required int FlowerId;
    public required FlowerType FlowerType { get; init; }
    public int? LengthInCm { get; init; }
    public required FlowerColor Color { get; init; }
}