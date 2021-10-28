namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;

    public class ReservationState
    {
        public int Id { get; set; }
        public ReservationStateEnum ReservationStatus { get; set; }
    }
}
