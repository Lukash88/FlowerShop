namespace FlowerShop.DataAccess.Entities
{
    using FlowerShop.DataAccess.Enums;
    using System;

    public class Reservation : EntityBase
    {
        public DateTime DateOfEvent { get; set; }
        public DateTime ReservedOn { get; set; }
        public ReservationStateEnum ReservationStatus{ get; set; }
        public EventType EventType { get; set; }
        public string EventDescription { get; set; }
        public string EventStreet { get; set; }
        public string EventCity { get; set; }
        public string EventPostalCode { get; set; }
        public decimal? ServicePrice { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}