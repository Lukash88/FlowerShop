using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class DecorationsProfile : Profile
    {
        public DecorationsProfile()
        {
            CreateMap<AddDecorationRequest, Decoration>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel));

            CreateMap<Decoration, DecorationDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.LongDescription, opt => opt.MapFrom(src => src.LongDescription))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.ImageThumbnailUrl, opt => opt.MapFrom(src => src.ImageThumbnailUrl))
                .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
                .ReverseMap();

            CreateMap<RemoveDecorationRequest, Decoration>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DecorationId));

            CreateMap<UpdateDecorationRequest, Decoration>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DecorationId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel));
        }
    }
}                 