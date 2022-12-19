namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.DataAccess.Entities;

    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            this.CreateMap<AddReservationRequest, Reservation>()
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DateOfEvent, y => y.MapFrom(z => z.DateOfEvent))
                .ForMember(x => x.ReservedOn, y => y.MapFrom(z => z.ReservedOn))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.EventDescription, y => y.MapFrom(z => z.EventDescription))
                .ForMember(x => x.EventStreet, y => y.MapFrom(z => z.EventStreet))
                .ForMember(x => x.EventCity, y => y.MapFrom(z => z.EventCity))
                .ForMember(x => x.EventPostalCode, y => y.MapFrom(z => z.EventPostalCode))
                .ForMember(x => x.ServicePrice, y => y.MapFrom(z => z.ServicePrice));

            this.CreateMap<Reservation, ReservationDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DateOfEvent, y => y.MapFrom(z => z.DateOfEvent))
                .ForMember(x => x.ReservedOn, y => y.MapFrom(z => z.ReservedOn))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.EventDescription, y => y.MapFrom(z => z.EventDescription))
                .ForMember(x => x.EventStreet, y => y.MapFrom(z => z.EventStreet))
                .ForMember(x => x.EventCity, y => y.MapFrom(z => z.EventCity))
                .ForMember(x => x.EventPostalCode, y => y.MapFrom(z => z.EventPostalCode));

            this.CreateMap<RemoveReservationRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ReservationId));

            this.CreateMap<UpdateReservationRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ReservationId))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.DateOfEvent, y => y.MapFrom(z => z.DateOfEvent))
                .ForMember(x => x.ReservedOn, y => y.MapFrom(z => z.ReservedOn))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.EventDescription, y => y.MapFrom(z => z.EventDescription))
                .ForMember(x => x.EventStreet, y => y.MapFrom(z => z.EventStreet))
                .ForMember(x => x.EventCity, y => y.MapFrom(z => z.EventCity))
                .ForMember(x => x.EventPostalCode, y => y.MapFrom(z => z.EventPostalCode))
                .ForMember(x => x.ServicePrice, y => y.MapFrom(z => z.ServicePrice));
        }
    }
}