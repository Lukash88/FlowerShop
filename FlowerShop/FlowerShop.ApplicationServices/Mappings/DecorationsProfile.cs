using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class DecorationsProfile : Profile
    {
        public DecorationsProfile()
        {
            this.CreateMap<DataAccess.Entities.Decoration, Decoration>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.Roles))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.IsAvailable, y => y.MapFrom(z => z.IsAvailable))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }
    }
}
                 