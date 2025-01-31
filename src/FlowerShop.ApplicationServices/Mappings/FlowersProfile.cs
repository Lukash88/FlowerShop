using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings;

public class FlowersProfile : Profile
{
    public FlowersProfile()
    {
        CreateMap<AddFlowerRequest, Flower>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FlowerType, opt => opt.MapFrom(src => src.FlowerType))
            .ForMember(dest => dest.LengthInCm, opt => opt.MapFrom(src => src.LengthInCm))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        CreateMap<Flower, FlowerDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FlowerType, opt => opt.MapFrom(src => src.FlowerType))
            .ForMember(dest => dest.LengthInCm, opt => opt.MapFrom(src => src.LengthInCm))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ReverseMap();

        CreateMap<RemoveFlowerRequest, Flower>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FlowerId));

        CreateMap<UpdateFlowerRequest, Flower>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FlowerId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FlowerType, opt => opt.MapFrom(src => src.FlowerType))
            .ForMember(dest => dest.LengthInCm, opt => opt.MapFrom(src => src.LengthInCm))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
    }
}