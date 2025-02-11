﻿using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class GetReservationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
{
    public async Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetReservationQuery
        {
            Id = request.ReservationId
        };
        var reservation = await queryExecutor.Execute(query);
        if (reservation is null)
        {
            return new GetReservationByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedReservation = mapper.Map<Domain.Models.ReservationDto>(reservation);
        var response = new GetReservationByIdResponse
        {
            Data = mappedReservation
        };

        return response;
    }
}