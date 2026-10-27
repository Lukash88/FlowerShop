using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation;

public class GetReservationByIdForUserRequest : IRequest<GetReservationByIdResponse>
{
    public required string Email { get; init; }
    public int Id { get; init; }
}