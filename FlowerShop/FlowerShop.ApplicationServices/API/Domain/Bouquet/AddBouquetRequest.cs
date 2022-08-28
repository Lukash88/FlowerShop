namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.DataAccess.Enums;
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class AddBouquetRequest : IRequest<AddBouquetResponse>
    {
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }

        public List<Tuple<int, int>> FlowersIdAndQuandity { get; set; } = new();
        public List<FlowerDTO> Flowers = new();
    }
}