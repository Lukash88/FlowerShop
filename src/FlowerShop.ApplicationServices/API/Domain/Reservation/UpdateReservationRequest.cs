using FlowerShop.DataAccess.Core.Enums;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    public class UpdateReservationRequest : IRequest<UpdateReservationResponse>
    {
        public int ReservationId;
        public int OrderId { get; init; }
        public DateTime DateOfEvent { get; init; }
        public DateTime ReservedOn { get; init; }
        public ReservationStateEnum ReservationStatus { get; init; }
        public EventType EventType { get; init; }
        public string EventDescription { get; init; }
        public string EventStreet { get; init; }
        public string EventCity { get; init; }
        public string EventPostalCode { get; init; }
        public decimal? ServicePrice { get; init; }
    }
}