namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.DataAccess.Entities;


    public class DecorationsProfile : Profile
    {
        public DecorationsProfile()
        {
            this.CreateMap<AddDecorationRequest, Decoration>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.Role))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.IsAvailable, y => y.MapFrom(z => z.IsAvailable))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

            this.CreateMap<Decoration, API.Domain.Models.DecorationDTO>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
               .ForMember(x => x.Role, y => y.MapFrom(z => z.Roles))
               .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
               .ForMember(x => x.IsAvailable, y => y.MapFrom(z => z.IsAvailable))
               .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

            this.CreateMap<RemoveDecorationRequest, Decoration>()
              .ForMember(x => x.Id, y => y.MapFrom(z => z.DecorationId));

            this.CreateMap<UpdateDecorationRequest, Decoration>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.DecorationId))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
               .ForMember(x => x.Roles, y => y.MapFrom(z => z.Role))
               .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
               .ForMember(x => x.IsAvailable, y => y.MapFrom(z => z.IsAvailable))
               .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }
    }
}                 