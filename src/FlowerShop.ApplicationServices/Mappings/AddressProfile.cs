using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.Identity;

namespace FlowerShop.ApplicationServices.Mappings;

internal class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AppUser, AddressDto>()
            .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.Address.FirstName))
            .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.Address.LastName))
            .ForPath(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForPath(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
            .ForPath(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ReverseMap();
    }
}