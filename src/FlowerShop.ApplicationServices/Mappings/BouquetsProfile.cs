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
            CreateMap<AddBouquetRequest, Bouquet>()
                .ForMember(dest => dest.Occasion, opt => opt.MapFrom(src => src.Occasion))
                .ForMember(dest => dest.TypeOfArrangement, opt => opt.MapFrom(src => src.TypeOfArrangement))
                .ForMember(dest => dest.DecorationWay, opt => opt.MapFrom(src => src.DecorationWay))
                .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
                .ForMember(dest => dest.Flowers, opt => opt.MapFrom(src => src.Flowers ?? new List<FlowerDto>()));

            CreateMap<Bouquet, BouquetFlower>()
                .ForMember(dest => dest.BouquetId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FlowerId, opt => opt.MapFrom(src => src.Flowers.Select(dest => dest.Id)));

            CreateMap<Bouquet, BouquetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Occasion, opt => opt.MapFrom(src => src.Occasion))
                .ForMember(dest => dest.TypeOfArrangement, opt => opt.MapFrom(src => src.TypeOfArrangement))
                .ForMember(dest => dest.DecorationWay, opt => opt.MapFrom(src => src.DecorationWay))
                .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
                .ForMember(dest => dest.Flowers, opt => opt.MapFrom(src => src.Flowers))
                .ReverseMap();

            CreateMap<Flower, FlowerDto>().ReverseMap();

            CreateMap<RemoveBouquetRequest, Bouquet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BouquetId));

            CreateMap<UpdateBouquetRequest, Bouquet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BouquetId))
                .ForMember(dest => dest.Occasion, opt => opt.MapFrom(src => src.Occasion))
                .ForMember(dest => dest.TypeOfArrangement, opt => opt.MapFrom(src => src.TypeOfArrangement))
                .ForMember(dest => dest.DecorationWay, opt => opt.MapFrom(src => src.DecorationWay))
                .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel));
        }
    }
}