using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class ReservationDto
    {
        public int Id { get; init; }
        public int OrderId { get; init; }
        public DateTime DateOfEvent { get; init; }
        public DateTime ReservedOn { get; init; }
        public ReservationState ReservationStatus { get; init; }
        public EventType EventType { get; init; }
        public string EventDescription { get; init; }     
        public string EventStreet { get; init; }
        public string EventCity { get; init; }
        public string EventPostalCode { get; init; }
        public decimal? ServicePrice { get; init; }
    }
}