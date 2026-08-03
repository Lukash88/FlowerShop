using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities.ReservationAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Reservation;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;
using Microsoft.Extensions.Logging;
using ReservationEntity = FlowerShop.DataAccess.Core.Entities.ReservationAggregate.Reservation;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class UpdateReservationForUserHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor, ILogger<UpdateReservationForUserHandler> logger)
    : IRequestHandler<UpdateReservationForUserRequest, UpdateReservationResponse>
{
    public async Task<UpdateReservationResponse> Handle(UpdateReservationForUserRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating reservation with ID: {ReservationId} for user: {Email}", request.Id, request.Email);

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

        if (getReservation.Email != request.Email)
        {
            logger.LogWarning("User {Email} is not authorized to update reservation {ReservationId}", request.Email, request.Id);
            return new UpdateReservationResponse
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }

        var updatedReservation = new ReservationEntity
        {
            Id = getReservation.Id,
            Email = getReservation.Email,
            ReservedOn = getReservation.ReservedOn,
            ReservationStatus = getReservation.ReservationStatus,
            OrderId = getReservation.OrderId,
            EventType = request.EventType,
            DateOfEvent = request.DateOfEvent,
            EventDescription = request.EventDescription,
            ServicePrice = request.ServicePrice,
            EventAddress = new EventAddress
            {
                Line1 = request.EventAddressLine1,
                Line2 = request.EventAddressLine2,
                City = request.EventCity,
                State = request.EventState,
                PostalCode = request.EventPostalCode,
                Country = request.EventCountry,
            }
        };

        var command = new UpdateReservationCommand
        {
            Parameter = updatedReservation
        };
        var result = await commandExecutor.Execute(command);

        logger.LogInformation("Reservation with ID: {ReservationId} successfully updated by user: {Email}", request.Id, request.Email);

        return new UpdateReservationResponse
        {
            Data = mapper.Map<ReservationDto>(result)
        };
    }
}