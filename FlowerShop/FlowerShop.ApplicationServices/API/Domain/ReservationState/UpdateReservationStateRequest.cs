namespace FlowerShop.ApplicationServices.API.Domain.ReservationState
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class UpdateReservationStateRequest : IRequest<UpdateReservationStateResponse>
    {
        public int ReservationStateId;
        public int ReservationId { get; set; }
        public ReservationStateEnum ReservationStatus { get; set; }
    }
}
