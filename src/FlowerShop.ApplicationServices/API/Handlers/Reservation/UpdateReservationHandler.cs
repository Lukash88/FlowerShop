using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Reservation;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    public class UpdateReservationHandler : IRequestHandler<UpdateReservationRequest, UpdateReservationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateReservationHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateReservationResponse> Handle(UpdateReservationRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReservationQuery()
            {
                Id = request.ReservationId
            };
            var getReservation = await _queryExecutor.Execute(query);
            if (getReservation is null)
            {
                return new UpdateReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var reservationsQuery = new GetReservationsQuery();
            var getReservations = await _queryExecutor.ExecuteWithSieve(reservationsQuery);
            var ordersQuery = new GetOrdersQuery();
            var getOrders = await _queryExecutor.ExecuteWithSieve(ordersQuery);

            if (!getOrders.Select(x => x.Id).Contains(request.OrderId)) 
            {
                return new UpdateReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedReservation = _mapper.Map<DataAccess.Core.Entities.Reservation>(request);
            var command = new UpdateReservationCommand()
            {
                Parameter = mappedReservation
            };
            var updatedReservation = await _commandExecutor.Execute(command);
            var response =  new UpdateReservationResponse()
            {
                Data = _mapper.Map<Domain.Models.ReservationDto>(updatedReservation)
            };

            return response;
        }
    }
}