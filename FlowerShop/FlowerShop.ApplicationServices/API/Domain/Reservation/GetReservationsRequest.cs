namespace FlowerShop.ApplicationServices.API.Domain.Reservation
{
    using MediatR;
    using Sieve.Models;

    public class GetReservationsRequest : IRequest<GetReservationsResponse>
    {
        public SieveModel SieveModel { get; set; }
    }
}