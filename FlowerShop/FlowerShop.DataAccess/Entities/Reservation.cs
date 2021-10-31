namespace FlowerShop.DataAccess.Entities
{
    using System;

    public class Reservation : EntityBase
    {        
        public DateTime ReservedOn { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string EventStreet { get; set; }
        public string EventCity { get; set; }
        public string EventPostalCode { get; set; }
        public bool IsDateAvailable { get; set; } 
        public bool IsPaymentConfirmed { get; set; }
        public int InvoiceId { get; set; }
        public string Invoice { get; set; }
        public string PaymentReceipt { get; set; }
         
        public int UserId { get; set; }
        public User User { get; set; }

        public ReservationState ReservationStatus { get; set; }

        public OrderDetail OrderDetail { get; set; }
    }
}
