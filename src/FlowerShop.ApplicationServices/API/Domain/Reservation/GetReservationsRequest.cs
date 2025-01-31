using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation;

public class GetReservationsRequest : IRequest<GetReservationsResponse>
{
    public required SieveModel SieveModel { get; init; }
}