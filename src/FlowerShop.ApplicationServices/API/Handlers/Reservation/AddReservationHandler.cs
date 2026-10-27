using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Reservation;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class AddReservationHandler(ICommandExecutor commandExecutor, IMapper mapper,
    IQueryExecutor queryExecutor, ILogger<AddReservationHandler> logger)
    : IRequestHandler<AddReservationRequest, AddReservationResponse>
{
    public async Task<AddReservationResponse> Handle(AddReservationRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Adding new reservation for event type: {EventType}", request.EventType);

        if (request.OrderId.HasValue)
        {
            var orderQuery = new GetOrderQuery
            {
                Id = request.OrderId.Value
            };
            var order = await queryExecutor.Execute(orderQuery);

            if (order is null)
            {
                logger.LogWarning("Order with ID: {OrderId} not found", request.OrderId);
                return new AddReservationResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
        }

        var reservation = mapper.Map<DataAccess.Core.Entities.ReservationAggregate.Reservation>(request);
        var command = new AddReservationCommand { Parameter = reservation };
        var addedReservation = await commandExecutor.Execute(command);

        logger.LogInformation("Reservation successfully added with ID: {ReservationId}", addedReservation.Id);

        return new AddReservationResponse
        {
            Data = mapper.Map<ReservationDto>(addedReservation)
        };
    }
}