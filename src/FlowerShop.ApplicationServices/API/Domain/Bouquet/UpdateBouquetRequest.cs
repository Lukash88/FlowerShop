using System.Collections.Generic;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class UpdateBouquetRequest : UpdateProductRequest, IRequest<UpdateBouquetResponse>
    {
        public int BouquetId;
        public Occasion Occasion { get; init; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; init; }
        public DecorationWay DecorationWay { get; init; }
        public List<FlowerDto> Flowers { get; init; } = new();
    }
}