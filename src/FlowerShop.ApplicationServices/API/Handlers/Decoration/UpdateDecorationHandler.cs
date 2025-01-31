using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Decoration;
using FlowerShop.DataAccess.CQRS.Queries.Decoration;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration;

public class UpdateDecorationHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    : IRequestHandler<UpdateDecorationRequest, UpdateDecorationResponse>
{
    public async  Task<UpdateDecorationResponse> Handle(UpdateDecorationRequest request, CancellationToken cancellationToken)
    {
        var query = new GetDecorationQuery
        {
            Id = request.DecorationId
        };
        var getDecoration = await queryExecutor.Execute(query);
        if (getDecoration is null)
        {
            return new UpdateDecorationResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedDecoration = mapper.Map<DataAccess.Core.Entities.Decoration>(request);
        var command = new UpdateDecorationCommand
        {
            Parameter = mappedDecoration
        };
        var updatedDecoration = await commandExecutor.Execute(command);
        var response = new UpdateDecorationResponse
        {
            Data = mapper.Map<DecorationDto>(updatedDecoration)
        };

        return response;
    }
}