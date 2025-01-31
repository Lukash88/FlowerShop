using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Reservation;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation;

public class RemoveReservationHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor) : IRequestHandler<RemoveReservationRequest, RemoveReservationResponse>
{
    public async Task<RemoveReservationResponse> Handle(RemoveReservationRequest request, 
        CancellationToken cancellationToken)
    {
        var query = new GetReservationQuery
        {
            Id = request.ReservationId
        };
        var getReservation = await queryExecutor.Execute(query);
        if (getReservation is null)
        {
            return new RemoveReservationResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedReservation = mapper.Map<DataAccess.Core.Entities.Reservation>(request);
        var command = new RemoveReservationCommand
        {
            Parameter = mappedReservation
        };
        var removedReservation = await commandExecutor.Execute(command);
        var response = new RemoveReservationResponse
        {
            Data = mapper.Map<Domain.Models.ReservationDto>(removedReservation)
        };

        return response;
    }
}