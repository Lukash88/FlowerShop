namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Reservation;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetReservationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReservationsQuery()
            {
                EventType = request.EventType
            };
            var reservations = await this.queryExecutor.Execute(query);
            var mappedReservations = this.mapper.Map<List<Domain.Models.ReservationDTO>>(reservations);
            var response = new GetReservationsResponse()
            {
                Data = mappedReservations
            };

            return response;
        }
    }
}
