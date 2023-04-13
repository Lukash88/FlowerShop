using System.Collections.Generic;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class UpdateBouquetRequest : IRequest<UpdateBouquetResponse>
    {
        public int BouquetId;
        public Occasion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public DecorationWay DecorationWay { get; set; }
        public int StockLevel { get; set; }
        public List<FlowerDto> Flowers { get; set; } = new();
    }
}