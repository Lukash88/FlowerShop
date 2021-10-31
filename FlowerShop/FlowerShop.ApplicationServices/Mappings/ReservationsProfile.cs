namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Models;

    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            this.CreateMap<DataAccess.Entities.Reservation, ReservationDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.EventDescription, y => y.MapFrom(z => z.EventDescription))
                .ForMember(x => x.DateOfEvent, y => y.MapFrom(z => z.DateOfEvent))
                .ForMember(x => x.EventStreet, y => y.MapFrom(z => z.EventStreet))
                .ForMember(x => x.EventCity, y => y.MapFrom(z => z.EventCity))
                .ForMember(x => x.EventPostalCode, y => y.MapFrom(z => z.EventPostalCode));
        }
    }
}
