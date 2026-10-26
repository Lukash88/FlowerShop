using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.DataAccess.Core.Entities.ReservationAggregate;

namespace FlowerShop.ApplicationServices.Mappings;

public class ReservationsProfile : Profile
{
    public ReservationsProfile()
    {
        CreateMap<AddReservationRequest, Reservation>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.DateOfEvent, opt => opt.MapFrom(src => src.DateOfEvent))
            .ForMember(dest => dest.ReservedOn, opt => opt.MapFrom(src => src.ReservedOn))
            .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus))
            .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType))
            .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
            .ForPath(dest => dest.EventAddress.Line1, opt => opt.MapFrom(src => src.EventAddressLine1))
            .ForPath(dest => dest.EventAddress.Line2, opt => opt.MapFrom(src => src.EventAddressLine2))
            .ForPath(dest => dest.EventAddress.City, opt => opt.MapFrom(src => src.EventCity))
            .ForPath(dest => dest.EventAddress.PostalCode, opt => opt.MapFrom(src => src.EventPostalCode))
            .ForPath(dest => dest.EventAddress.State, opt => opt.MapFrom(src => src.EventState))
            .ForPath(dest => dest.EventAddress.Country, opt => opt.MapFrom(src => src.EventCountry))
            .ForMember(dest => dest.ServicePrice, opt => opt.MapFrom(src => src.ServicePrice));

        CreateMap<Reservation, ReservationDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.DateOfEvent, opt => opt.MapFrom(src => src.DateOfEvent))
            .ForMember(dest => dest.ReservedOn, opt => opt.MapFrom(src => src.ReservedOn))
            .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus))
            .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType))
            .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
            .ForMember(dest => dest.EventAddressLine1, opt => opt.MapFrom(src => src.EventAddress.Line1))
            .ForMember(dest => dest.EventAddressLine2, opt => opt.MapFrom(src => src.EventAddress.Line2))
            .ForMember(dest => dest.EventCity, opt => opt.MapFrom(src => src.EventAddress.City))
            .ForMember(dest => dest.EventPostalCode, opt => opt.MapFrom(src => src.EventAddress.PostalCode))
            .ForMember(dest => dest.EventState, opt => opt.MapFrom(src => src.EventAddress.State))
            .ForMember(dest => dest.EventCountry, opt => opt.MapFrom(src => src.EventAddress.Country))
            .ReverseMap();

        CreateMap<CancelReservationByIdRequest, Reservation>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<UpdateReservationRequest, Reservation>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.DateOfEvent, opt => opt.MapFrom(src => src.DateOfEvent))
            .ForMember(dest => dest.ReservedOn, opt => opt.MapFrom(src => src.ReservedOn))
            .ForMember(dest => dest.ReservationStatus, opt => opt.MapFrom(src => src.ReservationStatus))
            .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType))
            .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
            .ForPath(dest => dest.EventAddress.Line1, opt => opt.MapFrom(src => src.EventAddressLine1))
            .ForPath(dest => dest.EventAddress.Line2, opt => opt.MapFrom(src => src.EventAddressLine2))
            .ForPath(dest => dest.EventAddress.City, opt => opt.MapFrom(src => src.EventCity))
            .ForPath(dest => dest.EventAddress.PostalCode, opt => opt.MapFrom(src => src.EventPostalCode))
            .ForPath(dest => dest.EventAddress.State, opt => opt.MapFrom(src => src.EventState))
            .ForPath(dest => dest.EventAddress.Country, opt => opt.MapFrom(src => src.EventCountry))
            .ForMember(dest => dest.ServicePrice, opt => opt.MapFrom(src => src.ServicePrice));
    }
}