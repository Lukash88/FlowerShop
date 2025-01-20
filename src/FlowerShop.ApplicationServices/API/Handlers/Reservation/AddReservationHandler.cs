using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Reservation;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class AddReservationHandler(ICommandExecutor commandExecutor, IMapper mapper,
    IQueryExecutor queryExecutor) : IRequestHandler<AddReservationRequest, AddReservationResponse>
{
    public async Task<AddReservationResponse> Handle(AddReservationRequest request,
        CancellationToken cancellationToken)
    {
        var reservationsQuery = new GetReservationsQuery();
        var getReservations = await queryExecutor.ExecuteWithSieve(reservationsQuery);
        var ordersQuery = new GetOrdersQuery();
        var getOrders = await queryExecutor.ExecuteWithSieve(ordersQuery);

        if (!getOrders.Select(x => x.Id).Contains(request.OrderId))
        {
            return new AddReservationResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var reservation = mapper.Map<DataAccess.Core.Entities.Reservation>(request);
        var command = new AddReservationCommand
        { 
            Parameter = reservation 
        };
        var addedReservation = await commandExecutor.Execute(command);
        var response = new AddReservationResponse
        {
            Data = mapper.Map<Domain.Models.ReservationDto>(addedReservation)
        };

        return response;
    }
}