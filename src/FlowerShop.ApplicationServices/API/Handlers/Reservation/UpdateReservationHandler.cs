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

public class UpdateReservationHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor) : IRequestHandler<UpdateReservationRequest, UpdateReservationResponse>
{
    public async Task<UpdateReservationResponse> Handle(UpdateReservationRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetReservationQuery
        {
            Id = request.ReservationId
        };
        var getReservation = await queryExecutor.Execute(query);
        if (getReservation is null)
        {
            return new UpdateReservationResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var reservationsQuery = new GetReservationsQuery();
        var getReservations = await queryExecutor.ExecuteWithSieve(reservationsQuery);
        var ordersQuery = new GetOrdersQuery();
        var getOrders = await queryExecutor.ExecuteWithSieve(ordersQuery);

        if (!getOrders.Select(x => x.Id).Contains(request.OrderId)) 
        {
            return new UpdateReservationResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedReservation = mapper.Map<DataAccess.Core.Entities.Reservation>(request);
        var command = new UpdateReservationCommand
        {
            Parameter = mappedReservation
        };
        var updatedReservation = await commandExecutor.Execute(command);
        var response =  new UpdateReservationResponse
        {
            Data = mapper.Map<Domain.Models.ReservationDto>(updatedReservation)
        };

        return response;
    }
}