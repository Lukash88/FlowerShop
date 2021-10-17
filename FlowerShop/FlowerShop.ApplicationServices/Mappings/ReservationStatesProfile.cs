using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class ReservationStatesProfile : Profile
    {
        public ReservationStatesProfile()
        {
            this.CreateMap<DataAccess.Entities.ReservationState, ReservationState>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus));
        }
    }
}
