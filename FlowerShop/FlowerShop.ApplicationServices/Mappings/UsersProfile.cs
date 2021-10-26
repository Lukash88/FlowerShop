namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Models;

    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.Roles))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.SecondName, y => y.MapFrom(z => z.SecondName))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City));
        }
    }
}
