namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using MediatR;
    using System;

    public class UpdateReservationRequest : IRequest<UpdateReservationResponse>
    {
        public int ReservationId;
        public int UserId { get; set; }
        public DateTime ReservedOn { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public DateTime DateOfEvent { get; set; }
        public bool IsDateAvailable { get; set; }
        public bool IsPaymentConfirmed { get; set; }
        public int InvoiceId { get; set; }
        public string Invoice { get; set; }
        public string EventStreet { get; set; }
        public string EventCity { get; set; }
        public string EventPostalCode { get; set; }
        public string PaymentReceipt { get; set; }
    }
}
