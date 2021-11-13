namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FlowerShop.DataAccess.Entities;

    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<AddUserRequest, User>()
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.Roles))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.SecondName, y => y.MapFrom(z => z.SecondName))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City));

            this.CreateMap<User, API.Domain.Models.UserDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.Roles))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.SecondName, y => y.MapFrom(z => z.SecondName))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City));

            this.CreateMap<RemoveUserRequest, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.UserId));

            this.CreateMap<UpdateUserRequest, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.Roles))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.SecondName, y => y.MapFrom(z => z.SecondName))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.PostalCode))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City));
        }
    }
}