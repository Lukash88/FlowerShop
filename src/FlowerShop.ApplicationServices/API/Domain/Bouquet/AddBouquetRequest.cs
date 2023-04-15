using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class AddBouquetRequest : IRequest<AddBouquetResponse>
    {
        public Occasion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }

        public List<Tuple<int, int>> FlowersIdAndQuantity { get; set; } = new();
        public List<FlowerDto> Flowers = new();
    }
}