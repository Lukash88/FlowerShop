using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
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
            if (reservation == null)
            {
                return new GetReservationByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedReservation = this.mapper.Map<Domain.Models.ReservationDto>(reservation);
            var response = new GetReservationByIdResponse()
            {
                Data = mappedReservation
            };

            return response;
        }
    }
}