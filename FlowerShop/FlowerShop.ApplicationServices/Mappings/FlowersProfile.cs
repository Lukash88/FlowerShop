using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.ApplicationServices.API.Domain.Models;
namespace FlowerShop.ApplicationServices.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FlowerShop.DataAccess.Entities;

    public class FlowersProfile : Profile
    {
        public FlowersProfile()
        {
            this.CreateMap<AddFlowerRequest, Flower>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.FlowerType, y => y.MapFrom(z => z.FlowerType))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LengthInCm, y => y.MapFrom(z => z.LengthInCm))
                .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour));


            this.CreateMap<Flower, API.Domain.Models.Flower>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.FlowerType, y => y.MapFrom(z => z.FlowerType))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LengthInCm, y => y.MapFrom(z => z.LengthInCm))
                .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour));

            this.CreateMap<RemoveFlowerRequest, Flower>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.FlowerId));

            this.CreateMap<UpdateFlowerRequest, Flower>()
                  .ForMember(x => x.Id, y => y.MapFrom(z => z.FlowerId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.FlowerType, y => y.MapFrom(z => z.FlowerType))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LengthInCm, y => y.MapFrom(z => z.LengthInCm))
                .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour));
            }
        }
}

