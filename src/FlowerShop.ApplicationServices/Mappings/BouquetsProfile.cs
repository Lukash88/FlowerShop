using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings;

public class BouquetsProfile : Profile
{
    public BouquetsProfile()
    {
        CreateMap<AddBouquetRequest, Bouquet>()
            .ForMember(dest => dest.Occasion, opt => opt.MapFrom(src => src.Occasion))
            .ForMember(dest => dest.TypeOfArrangement, opt => opt.MapFrom(src => src.TypeOfArrangement))
            .ForMember(dest => dest.DecorationWay, opt => opt.MapFrom(src => src.DecorationWay))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel));
              
        CreateMap<Bouquet, BouquetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Occasion, opt => opt.MapFrom(src => src.Occasion))
            .ForMember(dest => dest.TypeOfArrangement, opt => opt.MapFrom(src => src.TypeOfArrangement))
            .ForMember(dest => dest.DecorationWay, opt => opt.MapFrom(src => src.DecorationWay))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
            .ReverseMap();

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