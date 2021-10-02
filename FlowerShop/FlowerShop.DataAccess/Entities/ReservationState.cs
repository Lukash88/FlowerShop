using FlowerShop.DataAccess.Enums;

namespace FlowerShop.DataAccess.Entities
{
    public class ReservationState : EntityBase
    {
        public ReservationStateEnum ReservationStatus{ get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}