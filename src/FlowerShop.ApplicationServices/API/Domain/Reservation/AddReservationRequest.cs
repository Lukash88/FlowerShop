using System;
using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    public class AddReservationRequest : IRequest<AddReservationResponse>
    {
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