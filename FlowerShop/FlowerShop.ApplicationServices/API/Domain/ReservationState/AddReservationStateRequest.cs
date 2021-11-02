namespace FlowerShop.ApplicationServices.API.Domain.ReservationState
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class AddReservationStateRequest : IRequest<AddReservationStateResponse>
    {
        public int ReservationId { get; set; }
        public ReservationStateEnum ReservationStatus { get; set; }
    }
}
