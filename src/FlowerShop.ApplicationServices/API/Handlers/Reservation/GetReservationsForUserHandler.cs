using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using Microsoft.Extensions.Logging;
using Sieve.Services;
using ReservationEntity = FlowerShop.DataAccess.Core.Entities.ReservationAggregate.Reservation;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class GetReservationsForUserHandler(
    IMapper mapper,
    IQueryExecutor queryExecutor,
    ISieveProcessor sieveProcessor,
    ILogger<GetReservationsForUserHandler> logger)
    : PagedRequestHandler<GetReservationsForUserRequest, GetReservationsResponse>
{
    public override async Task<GetReservationsResponse> Handle(GetReservationsForUserRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting reservations for user: {Email}", request.Email);

        var query = new GetReservationsForUserQuery
        {
            Email = request.Email,
            SieveModel = request.SieveModel
        };

        var reservations = await queryExecutor.ExecuteWithSieve(query);
        if (reservations is null)
        {
            return new GetReservationsResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var results = await reservations.ToPagedAsync<ReservationEntity, ReservationDto>(sieveProcessor,
            mapper, query.SieveModel, cancellationToken: cancellationToken);
        var response = new GetReservationsResponse
        {
            Data = results
        };

        return response;
    }
}