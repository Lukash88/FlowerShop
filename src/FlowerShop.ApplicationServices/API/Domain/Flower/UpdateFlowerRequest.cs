using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    public class UpdateFlowerRequest : UpdateProductRequest, IRequest<UpdateFlowerResponse>
    {
        public int FlowerId;
        public FlowerType FlowerType { get; init; }
        public int? LengthInCm { get; init; }
        public FlowerColor Color { get; init; }
    }
}