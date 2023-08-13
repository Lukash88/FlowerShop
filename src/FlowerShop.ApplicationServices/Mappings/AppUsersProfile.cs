using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.DataAccess.Core.Entities.Identity;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using Address = FlowerShop.DataAccess.Core.Entities.Identity.Address;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class AppUsersProfile : Profile
    {
        public AppUsersProfile()
        {
            CreateMap<RegisterAppUserRequest, AppUser>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.Address.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.Address.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ReverseMap();

            CreateMap<AppUser, AppUserDto>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ReverseMap();

            CreateMap<RegisterAppUserRequest, AppUserDto>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ReverseMap();

            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<AppUser, AddressDto>()
                .ForPath(dest => dest.FirstName, opt => opt.MapFrom(src => src.Address.FirstName))
                .ForPath(dest => dest.LastName, opt => opt.MapFrom(src => src.Address.LastName))
                .ForPath(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForPath(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForPath(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ReverseMap();

            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ReverseMap();

            CreateMap<UpdateUserRequest, AppUser>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ReverseMap();


            CreateMap<UpdateUserAddressRequest, Address>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}