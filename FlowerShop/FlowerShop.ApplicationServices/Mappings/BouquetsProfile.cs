using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class BouquetsProfile : Profile
    {
        public BouquetsProfile()
        {
            this.CreateMap<DataAccess.Entities.Bouquet, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay));
        }
    }
}
