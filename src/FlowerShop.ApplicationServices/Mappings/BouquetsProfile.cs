using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class BouquetsProfile : Profile
    {
        public BouquetsProfile()
        {
            this.CreateMap<AddBouquetRequest, Bouquet>()
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Flowers, y => y.MapFrom(z => z.Flowers ?? new List<FlowerDto>()));

            this.CreateMap<Bouquet, BouquetFlower>()
                .ForMember(x => x.BouquetId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FlowerId, y => y.MapFrom(z => z.Flowers.Select(x => x.Id)));

            this.CreateMap<Bouquet, BouquetDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Flowers, y => y.MapFrom(z => z.Flowers))
                .ReverseMap();

            this.CreateMap<Flower, FlowerDto>().ReverseMap();

            this.CreateMap<RemoveBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId));

            this.CreateMap<UpdateBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel));
        }
    }
}