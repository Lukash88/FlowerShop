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

public class GetReservationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ILogger<GetReservationByIdHandler> logger)
    : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
{
    public async Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting reservation with ID: {ReservationId}", request.Id);

        var query = new GetReservationQuery
        {
            Id = request.Id
        };
        var reservation = await queryExecutor.Execute(query);
        if (reservation is null)
        {
            logger.LogWarning("Reservation with ID: {ReservationId} not found", request.Id);
            return new GetReservationByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        logger.LogInformation("Reservation with ID: {ReservationId} retrieved successfully", request.Id);

        return new GetReservationByIdResponse
        {
            Data = mapper.Map<ReservationDto>(reservation)
        };
    }
}