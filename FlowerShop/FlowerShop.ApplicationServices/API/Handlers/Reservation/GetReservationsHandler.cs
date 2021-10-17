using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Reservation> reservationRepository;
        private readonly IMapper mapper;

        public GetReservationsHandler(IRepository<DataAccess.Entities.Reservation> reservationRepository,
            IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;
        }
        public async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var reservations = await this.reservationRepository.GetAll();
            var mappedReservations = this.mapper.Map<List<Domain.Models.Reservation>>(reservations);
            var response = new GetReservationsResponse()
            {
                Data = mappedReservations
            };

            return response;
        }
    }
}