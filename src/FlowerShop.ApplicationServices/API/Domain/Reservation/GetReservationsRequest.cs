using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    public class GetReservationsRequest : IRequest<GetReservationsResponse>
    {
        public SieveModel SieveModel { get; set; }
    }
}