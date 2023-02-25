using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    using MediatR;
    using System;

    public class UpdateReservationRequest : IRequest<UpdateReservationResponse>
    {
        public int ReservationId;
        public int OrderId { get; set; }
        public DateTime DateOfEvent { get; set; }
        public DateTime ReservedOn { get; set; }
        public ReservationStateEnum ReservationStatus { get; set; }
        public EventType EventType { get; set; }
        public string EventDescription { get; set; }
        public string EventStreet { get; set; }
        public string EventCity { get; set; }
        public string EventPostalCode { get; set; }
        public decimal? ServicePrice { get; set; }
    }
}