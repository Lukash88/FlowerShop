using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<AddReservationRequest, Reservation>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.DateOfEvent, opt => opt.MapFrom(src => src.DateOfEvent))
                .ForMember(dest => dest.ReservedOn, opt => opt.MapFrom(src => src.ReservedOn))
                .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus))
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType))
                .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
                .ForMember(dest => dest.EventStreet, opt => opt.MapFrom(src => src.EventStreet))
                .ForMember(dest => dest.EventCity, opt => opt.MapFrom(src => src.EventCity))
                .ForMember(dest => dest.EventPostalCode, opt => opt.MapFrom(src => src.EventPostalCode))
                .ForMember(dest => dest.ServicePrice, opt => opt.MapFrom(src => src.ServicePrice));

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.DateOfEvent, opt => opt.MapFrom(src => src.DateOfEvent))
                .ForMember(dest => dest.ReservedOn, opt => opt.MapFrom(src => src.ReservedOn))
                .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus))
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType))
                .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
                .ForMember(dest => dest.EventStreet, opt => opt.MapFrom(src => src.EventStreet))
                .ForMember(dest => dest.EventCity, opt => opt.MapFrom(src => src.EventCity))
                .ForMember(dest => dest.EventPostalCode, opt => opt.MapFrom(src => src.EventPostalCode));

            CreateMap<RemoveReservationRequest, Reservation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ReservationId));

            CreateMap<UpdateReservationRequest, Reservation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.DateOfEvent, opt => opt.MapFrom(src => src.DateOfEvent))
                .ForMember(dest => dest.ReservedOn, opt => opt.MapFrom(src => src.ReservedOn))
                .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus))
                .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType))
                .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
                .ForMember(dest => dest.EventStreet, opt => opt.MapFrom(src => src.EventStreet))
                .ForMember(dest => dest.EventCity, opt => opt.MapFrom(src => src.EventCity))
                .ForMember(dest => dest.EventPostalCode, opt => opt.MapFrom(src => src.EventPostalCode))
                .ForMember(dest => dest.ServicePrice, opt => opt.MapFrom(src => src.ServicePrice));
        }
    }
}