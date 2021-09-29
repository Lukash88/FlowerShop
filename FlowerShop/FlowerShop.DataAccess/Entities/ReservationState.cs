using FlowerShop.DataAccess.Enums;

namespace FlowerShop.DataAccess.Entities
{
    public class ReservationState : EntityBase
    {
        public ReservationStateEnum ReservationStates { get; set; }
    }
}