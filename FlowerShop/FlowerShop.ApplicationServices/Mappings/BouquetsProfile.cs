﻿namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public class BouquetsProfile : Profile
    {
        public BouquetsProfile()
        {
            this.CreateMap<AddBouquetRequest, Bouquet>().IncludeAllDerived()
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
               // .ForMember(x => x.Flowers.Select(x => x.Id), y => y.MapFrom(z => z.FlowersIds ?? new List<int>()));
            .ForMember(x => x.Flowers, y => y.MapFrom(z => z.Flowers ?? new List<FlowerDTO>()));
            //.ForMember(x => x.Flowers.Select(x => x.Name), y => y.MapFrom(z => z.FlowersNames ?? new List<string>()));

            this.CreateMap<Bouquet, API.Domain.Models.BouquetDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Flowers, y => y.MapFrom(z => z.Flowers ?? new List<Flower>()));
            //.ForMember(x => x.Flowers, y => y.MapFrom(z => z.Flowers != null ? 
            //    z.Flowers.Select(x => x.Name) : new List<string>()));

            this.CreateMap<RemoveBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId));

            this.CreateMap<UpdateBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel));
                //.ForMember(x => x.Flowers, y => y.MapFrom(z => z.FlowerNames ?? new List<string>()));
        }
    }
}