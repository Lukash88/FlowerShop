using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Reservation> reservationRepository;

        public GetReservationsHandler(IRepository<DataAccess.Entities.Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var reservations = this.reservationRepository.GetAll();
            var domainReservations = reservations.Select(x => new Domain.Models.Reservation()
            {
                Id = x.Id,
                EventType = x.EventType,
                EventDescription = x.EventDescription,
                DateOfEvent = x.DateOfEvent,
                EventStreet = x.EventStreet,
                EventCity = x.EventCity,
                EventPostalCode = x.EventPostalCode
            });

            var response = new GetReservationsResponse()
            {
                Data = domainReservations.ToList()
            };

            return Task.FromResult(response);
        }
    }
}