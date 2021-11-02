namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;

    public class ReservationStateDTO
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public ReservationStateEnum ReservationStatus { get; set; }
    }
}
