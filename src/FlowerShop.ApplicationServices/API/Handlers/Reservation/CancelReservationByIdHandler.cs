using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Enums;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Reservation;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class CancelReservationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor, ILogger<CancelReservationByIdHandler> logger)
    : IRequestHandler<CancelReservationByIdRequest, CancelReservationByIdResponse>
{
    public async Task<CancelReservationByIdResponse> Handle(CancelReservationByIdRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Cancelling reservation with ID: {ReservationId}", request.Id);

        var query = new GetReservationQuery
        {
            Id = request.Id
        };
        var reservation = await queryExecutor.Execute(query);
        if (reservation is null)
        {
            logger.LogWarning("Reservation with ID: {ReservationId} not found", request.Id);
            return new CancelReservationByIdResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }

        if (!string.IsNullOrEmpty(request.Email) && reservation.Email != request.Email)
        {
            logger.LogWarning("User {Email} is not authorized to cancel reservation {Id}", request.Email, request.Id);

            return new CancelReservationByIdResponse
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }

        var updatedReservationState = new DataAccess.Core.Entities.ReservationAggregate.Reservation
        {
            Id = reservation.Id,
            Email = reservation.Email,
            DateOfEvent = reservation.DateOfEvent,
            ReservedOn = reservation.ReservedOn,
            ReservationStatus = ReservationState.Cancelled,
            EventType = reservation.EventType,
            EventDescription = reservation.EventDescription,
            EventAddress = reservation.EventAddress,
            ServicePrice = reservation.ServicePrice,
            OrderId = reservation.OrderId
        };

        var command = new UpdateReservationCommand
        {
            Parameter = updatedReservationState
        };
        var cancelledReservation = await commandExecutor.Execute(command);

        logger.LogInformation("Reservation with ID: {ReservationId} successfully cancelled", request.Id);

        return new CancelReservationByIdResponse
        {
            Data = mapper.Map<ReservationDto>(cancelledReservation)
        };
    }
}