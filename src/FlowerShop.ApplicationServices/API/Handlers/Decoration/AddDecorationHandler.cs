using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Decoration;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration;

public class AddDecorationHandler(ICommandExecutor commandExecutor, IMapper mapper)
    : IRequestHandler<AddDecorationRequest, AddDecorationResponse>
{
    public async Task<AddDecorationResponse> Handle(AddDecorationRequest request, CancellationToken cancellationToken)
    {
        var decoration = mapper.Map<DataAccess.Core.Entities.Decoration>(request);
        var command = new AddDecorationCommand
        { 
            Parameter = decoration 
        };
        var addedDecoration = await commandExecutor.Execute(command);
        var response = new AddDecorationResponse
        {
            Data = mapper.Map<DecorationDto>(addedDecoration)
        };

        return response;
    }
}