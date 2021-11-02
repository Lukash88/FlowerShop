namespace FlowerShop.ApplicationServices.API.Domain.ReservationState
{
    using MediatR;

    public class RemoveReservationStateRequest : IRequest<RemoveReservationStateResponse>
    {
        public int ReservationStateId { get; init; }
    }
}
