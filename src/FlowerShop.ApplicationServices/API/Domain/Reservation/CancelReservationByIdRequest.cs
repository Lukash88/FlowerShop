using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation;

public class CancelReservationByIdRequest : IRequest<CancelReservationByIdResponse>
{
    public string? Email { get; init; }
    public required int Id { get; init; }
}