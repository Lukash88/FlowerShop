using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation;

public class RemoveReservationRequest : IRequest<RemoveReservationResponse>
{
    public required int ReservationId { get; init; }
}