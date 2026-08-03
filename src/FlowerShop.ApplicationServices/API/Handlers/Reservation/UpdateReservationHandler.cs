using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Reservation;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;
using Microsoft.Extensions.Logging;
using ReservationEntity = FlowerShop.DataAccess.Core.Entities.ReservationAggregate.Reservation;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class UpdateReservationHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor, ILogger<UpdateReservationHandler> logger)
    : IRequestHandler<UpdateReservationRequest, UpdateReservationResponse>
{
    public async Task<UpdateReservationResponse> Handle(UpdateReservationRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating reservation with ID: {ReservationId}", request.Id);

        var query = new GetReservationQuery
        { 
            Id = request.Id
        };
        var getReservation = await queryExecutor.Execute(query);
        if (getReservation is null)
        {
            logger.LogWarning("Reservation with ID: {ReservationId} not found", request.Id);
            return new UpdateReservationResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        if (request.OrderId.HasValue)
        {
            var orderQuery = new GetOrderQuery { Id = request.OrderId.Value };
            var order = await queryExecutor.Execute(orderQuery);
            if (order is null)
            {
                logger.LogWarning("Order with ID: {OrderId} not found", request.OrderId);
                return new UpdateReservationResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
        }

        var mappedReservation = mapper.Map<ReservationEntity>(request);
        var command = new UpdateReservationCommand
        {
            Parameter = mappedReservation
        };
        var updatedReservation = await commandExecutor.Execute(command);

        logger.LogInformation("Reservation with ID: {ReservationId} successfully updated", request.Id);

        return new UpdateReservationResponse
        {
            Data = mapper.Map<ReservationDto>(updatedReservation)
        };
    }
}