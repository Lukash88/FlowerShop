namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Reservation;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetReservationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReservationQuery()
            {
                Id = request.ReservationId
            };
            var reservation = await this.queryExecutor.Execute(query);
            var mappedReservation = this.mapper.Map<Domain.Models.ReservationDTO>(reservation);
            var response = new GetReservationByIdResponse()
            {
                Data = mappedReservation
            };

            return response;
        }
    }
}