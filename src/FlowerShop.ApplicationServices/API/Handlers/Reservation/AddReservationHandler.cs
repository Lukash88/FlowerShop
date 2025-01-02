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
    public class AddReservationHandler : IRequestHandler<AddReservationRequest, AddReservationResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public AddReservationHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<AddReservationResponse> Handle(AddReservationRequest request, CancellationToken cancellationToken)
        {
            var reservationsQuery = new GetReservationsQuery();
            var getReservations = await _queryExecutor.ExecuteWithSieve(reservationsQuery);
            var ordersQuery = new GetOrdersQuery();
            var getOrders = await _queryExecutor.ExecuteWithSieve(ordersQuery);

            if (!getOrders.Select(x => x.Id).Contains(request.OrderId))
            {
                return new AddReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var reservation = _mapper.Map<DataAccess.Core.Entities.Reservation>(request);
            var command = new AddReservationCommand() 
            { 
                Parameter = reservation 
            };
            var addedReservation = await _commandExecutor.Execute(command);
            var response = new AddReservationResponse()
            {
                Data = _mapper.Map<Domain.Models.ReservationDto>(addedReservation)
            };

            return response;
        }
    }
}