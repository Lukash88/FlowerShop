using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.Identity;

namespace FlowerShop.ApplicationServices.Mappings;

internal class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AppUser, AddressDto>()
            .ForPath(dest => dest.Line1, opt => opt.MapFrom(src => src.Address.Line1))
            .ForPath(dest => dest.Line2, opt => opt.MapFrom(src => src.Address.Line2))
            .ForPath(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForPath(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForPath(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
            .ForPath(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
            .ReverseMap();
    }
}