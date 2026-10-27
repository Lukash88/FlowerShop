using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation;

public class GetReservationsForUserRequest : IRequest<GetReservationsResponse>
{
    public required string Email { get; init; }
    public required SieveModel SieveModel { get; init; }
}