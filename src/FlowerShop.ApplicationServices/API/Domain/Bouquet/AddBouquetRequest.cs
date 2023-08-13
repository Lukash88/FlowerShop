using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using FlowerShop.ApplicationServices.API.Domain.Product;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class AddBouquetRequest : AddProductRequest, IRequest<AddBouquetResponse>
    {
        public Occasion Occasion { get; init; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; init; }
        public DecorationWay DecorationWay { get; init; }

        public List<Tuple<int, int>> FlowersIdAndQuantity { get; init; } = new();
        public List<FlowerDto> Flowers = new();
    }
}