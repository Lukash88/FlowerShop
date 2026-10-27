using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class GetReservationByIdForUserHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ILogger<GetReservationByIdForUserHandler> logger)
    : IRequestHandler<GetReservationByIdForUserRequest, GetReservationByIdResponse>
{
    public async Task<GetReservationByIdResponse> Handle(GetReservationByIdForUserRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting reservation {Id} for user {Email}", request.Id, request.Email);

        var reservation = await queryExecutor.Execute(new GetReservationQuery
        {
            Id = request.Id
        });
        if (reservation is null)
            return new GetReservationByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };

        if (reservation.Email != request.Email)
        {
            logger.LogWarning("User {Email} is not authorized to view reservation {Id}", request.Email, request.Id);
            return new GetReservationByIdResponse
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }

        return new GetReservationByIdResponse
        {
            Data = mapper.Map<ReservationDto>(reservation)
        };
    }
}