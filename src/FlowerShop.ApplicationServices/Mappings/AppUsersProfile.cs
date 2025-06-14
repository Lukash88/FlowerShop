using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.DataAccess.Core.Entities.Identity;
using Address = FlowerShop.DataAccess.Core.Entities.Identity.Address;

namespace FlowerShop.ApplicationServices.Mappings;

public class AppUsersProfile : Profile
{
    public AppUsersProfile()
    {
        CreateMap<RegisterAppUserRequest, AppUser>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForPath(dest => dest.Address.Line1, opt => opt.MapFrom(src => src.Line1))
            .ForPath(dest => dest.Address.Line2, opt => opt.MapFrom(src => src.Line2))
            .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
            .ForPath(dest => dest.Address.State, opt => opt.MapFrom(src => src.State))
            .ForPath(dest => dest.Address.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Country))
            
            .ReverseMap();

        CreateMap<AppUser, AppUserDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();

        CreateMap<RegisterAppUserRequest, AppUserDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();

        CreateMap<AppUser, UserDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();

        CreateMap<Address, AddressDto>()
            .ForMember(dest => dest.Line1, opt => opt.MapFrom(src => src.Line1))
            .ForMember(dest => dest.Line2, opt => opt.MapFrom(src => src.Line2))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ReverseMap();

        CreateMap<UpdateUserRequest, AppUser>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();

        CreateMap<UpdateUserAddressRequest, Address>()
            .ForMember(dest => dest.Line1, opt => opt.MapFrom(src => src.Line1))
            .ForMember(dest => dest.Line2, opt => opt.MapFrom(src => src.Line2))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ReverseMap();

        CreateMap<AppUser, UserInfoDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName ?? string.Empty))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName ?? string.Empty))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
    }
}