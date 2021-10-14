using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public class GetReservationHandler : IRequestHandler<GetReservationRequest, GetReservationResponse>
    {
        private readonly IRepository<Reservation> reservationRepository;

        public GetReservationHandler(IRepository<DataAccess.Entities.Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Task<GetReservationResponse> Handle(GetReservationRequest request, CancellationToken cancellationToken)
        {
            var reservations = this.reservationRepository.GetAll();
            var domainReservations = reservations.Select(x => new Domain.Models.Reservation()
            {
                EventType = x.EventType,
                EventDescription = x.EventDescription,
                DateOfEvent = x.DateOfEvent,
                EventStreet = x.EventStreet,
                EventCity = x.EventCity,
                EventPostalCode = x.EventPostalCode
            });

            var response = new GetReservationResponse()
            {
                Data = domainReservations.ToList()
            };

            return Task.FromResult(response);
        }
    }
}