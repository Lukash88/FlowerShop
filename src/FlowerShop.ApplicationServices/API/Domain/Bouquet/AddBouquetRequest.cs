using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class AddBouquetRequest : AddProductRequest, IRequest<AddBouquetResponse>
    {
        public Occasion Occasion { get; init; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; init; }
        public DecorationWay DecorationWay { get; init; }
    }
}