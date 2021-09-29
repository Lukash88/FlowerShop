using System;
using System.ComponentModel.DataAnnotations;

namespace FlowerShop.DataAccess.Entities
{
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

        public int ReservationId{ get; set; }
        public ReservationState ReservationStatus { get; set; }

        public int OrderId { get; set; }
        public OrderDetail OrderDetails { get; set; }

    }
}

/*
 * change into fluent api
 *  [Required]
        public DateTime ReservedOn { get; set; }
        [Required]
        public string EventType { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public DateTime DateOfEvent { get; set; }
        [Required]
        [MaxLength(100)]
        public string EventStreet { get; set; }
        [Required]
        [MaxLength(100)]
        public string EventCity { get; set; }
        [Required]
        [MaxLength(100)]
        public string EventPostalCode { get; set; }
        [Required]
        public bool IsDateAvailable { get; set; } 
*/
