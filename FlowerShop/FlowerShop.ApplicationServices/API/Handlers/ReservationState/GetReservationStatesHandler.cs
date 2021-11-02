namespace FlowerShop.ApplicationServices.API.Handlers.ReservationState
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.ReservationState;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.ReservationState;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetReservationStatesHandler : IRequestHandler<GetReservationStatesRequest, GetReservationStatesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetReservationStatesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }   

        public async Task<GetReservationStatesResponse> Handle(GetReservationStatesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReservationStatesQuery()
            {
                ReservationStatus = request.ReservationStatus
            };
            var reservationStates = await this.queryExecutor.Execute(query);
            var mappedReservationStates = this.mapper.Map<List<Domain.Models.ReservationStateDTO>>(reservationStates);
            var response = new GetReservationStatesResponse()
            {
                Data = mappedReservationStates
            };

            return response;
        }
    }
}
