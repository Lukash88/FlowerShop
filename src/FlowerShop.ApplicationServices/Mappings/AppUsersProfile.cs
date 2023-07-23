using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Entities.Identity;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class AppUsersProfile : Profile
    {
        public AppUsersProfile()
        {
            this.CreateMap<RegisterAppUserRequest, AppUser>()
                .ForMember(x => x.DisplayName, y => y.MapFrom(z => z.DisplayName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.Email))
                .ForPath(x => x.Address.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForPath(x => x.Address.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(z => z.DateOfBirth))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender))
                .ForPath(x => x.Address.Street, y => y.MapFrom(z => z.Street))
                .ForPath(x => x.Address.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForPath(x => x.Address.City, y => y.MapFrom(z => z.City))
                .ReverseMap();

            this.CreateMap<AppUser, AppUserDto>()
                .ForMember(x => x.DisplayName, y => y.MapFrom(z => z.DisplayName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(z => z.DateOfBirth))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender))
                .ReverseMap();

            this.CreateMap<RegisterAppUserRequest, AppUserDto>()
                .ForMember(x => x.DisplayName, y => y.MapFrom(z => z.DisplayName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(z => z.DateOfBirth))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender))
                .ReverseMap();

            this.CreateMap<AppUser, UserDto>()
                .ForMember(x => x.DisplayName, y => y.MapFrom(z => z.DisplayName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ReverseMap();

            this.CreateMap<AppUser, AddressDto>()
                .ForPath(x => x.FirstName, y => y.MapFrom(z => z.Address.FirstName))
                .ForPath(x => x.LastName, y => y.MapFrom(z => z.Address.LastName))
                .ForPath(x => x.Street, y => y.MapFrom(z => z.Address.Street))
                .ForPath(x => x.PostalCode, y => y.MapFrom(z => z.Address.PostalCode))
                .ForPath(x => x.City, y => y.MapFrom(z => z.Address.City))
                .ReverseMap();

            this.CreateMap<Address, AddressDto>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ReverseMap();

            this.CreateMap<UpdateUserRequest, AppUser>()
                .ForMember(x => x.DisplayName, y => y.MapFrom(z => z.DisplayName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(z => z.DateOfBirth))
                .ForMember(x => x.Gender, y => y.MapFrom(z => z.Gender))
                .ReverseMap();


            this.CreateMap<UpdateUserAddressRequest, Address>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ReverseMap();

            this.CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}