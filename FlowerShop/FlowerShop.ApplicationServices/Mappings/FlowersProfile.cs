using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class FlowersProfile : Profile
    {
        public FlowersProfile()
        {
            this.CreateMap<DataAccess.Entities.Flower, Flower>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.FlowerType, y => y.MapFrom(z => z.FlowerType))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LengthInCm, y => y.MapFrom(z => z.LengthInCm))
                .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour));
        }
    }
}

