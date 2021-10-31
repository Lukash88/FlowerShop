namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.DataAccess.Entities;

    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            this.CreateMap<AddReservationRequest, Reservation>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.EventDescription, y => y.MapFrom(z => z.EventDescription))
                .ForMember(x => x.EventStreet, y => y.MapFrom(z => z.EventStreet))
                .ForMember(x => x.EventCity, y => y.MapFrom(z => z.EventCity))
                .ForMember(x => x.EventPostalCode, y => y.MapFrom(z => z.EventPostalCode))
                .ForMember(x => x.ReservedOn, y => y.MapFrom(z => z.ReservedOn))
                .ForMember(x => x.DateOfEvent, y => y.MapFrom(z => z.DateOfEvent))
                .ForMember(x => x.IsDateAvailable, y => y.MapFrom(z => z.IsDateAvailable))
                .ForMember(x => x.IsPaymentConfirmed, y => y.MapFrom(z => z.IsPaymentConfirmed))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.PaymentReceipt, y => y.MapFrom(z => z.PaymentReceipt));

            this.CreateMap<Reservation, API.Domain.Models.ReservationDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.EventDescription, y => y.MapFrom(z => z.EventDescription))
                .ForMember(x => x.EventStreet, y => y.MapFrom(z => z.EventStreet))
                .ForMember(x => x.EventCity, y => y.MapFrom(z => z.EventCity))
                .ForMember(x => x.EventPostalCode, y => y.MapFrom(z => z.EventPostalCode))
                .ForMember(x => x.ReservedOn, y => y.MapFrom(z => z.ReservedOn))
                .ForMember(x => x.DateOfEvent, y => y.MapFrom(z => z.DateOfEvent))
                .ForMember(x => x.IsDateAvailable, y => y.MapFrom(z => z.IsDateAvailable))
                .ForMember(x => x.IsPaymentConfirmed, y => y.MapFrom(z => z.IsPaymentConfirmed))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.PaymentReceipt, y => y.MapFrom(z => z.PaymentReceipt));

            this.CreateMap<RemoveReservationRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ReservationId));

            this.CreateMap<UpdateReservationRequest, Reservation>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ReservationId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.EventDescription, y => y.MapFrom(z => z.EventDescription))
                .ForMember(x => x.EventStreet, y => y.MapFrom(z => z.EventStreet))
                .ForMember(x => x.EventCity, y => y.MapFrom(z => z.EventCity))
                .ForMember(x => x.EventPostalCode, y => y.MapFrom(z => z.EventPostalCode))
                .ForMember(x => x.ReservedOn, y => y.MapFrom(z => z.ReservedOn))
                .ForMember(x => x.DateOfEvent, y => y.MapFrom(z => z.DateOfEvent))
                .ForMember(x => x.IsDateAvailable, y => y.MapFrom(z => z.IsDateAvailable))
                .ForMember(x => x.IsPaymentConfirmed, y => y.MapFrom(z => z.IsPaymentConfirmed))
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.PaymentReceipt, y => y.MapFrom(z => z.PaymentReceipt));
        }
    }
}
