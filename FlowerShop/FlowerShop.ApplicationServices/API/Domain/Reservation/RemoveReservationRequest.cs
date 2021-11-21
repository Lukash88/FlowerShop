namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    using MediatR;

    public class RemoveReservationRequest : IRequest<RemoveReservationResponse>
    {
        public int ReservationId { get; init; }
    }
}