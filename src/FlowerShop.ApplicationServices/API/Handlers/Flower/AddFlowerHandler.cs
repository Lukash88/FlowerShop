using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Flower;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower;

public class AddFlowerHandler(ICommandExecutor commandExecutor, IMapper mapper)
    : IRequestHandler<AddFlowerRequest, AddFlowerResponse>
{
    public async Task<AddFlowerResponse> Handle(AddFlowerRequest request, CancellationToken cancellationToken)
    {
        var flower = mapper.Map<DataAccess.Core.Entities.Flower>(request);
        var command = new AddFlowerCommand
        { 
            Parameter = flower 
        };
        var addedFlower = await commandExecutor.Execute(command);
        var response =  new AddFlowerResponse
        {
            Data = mapper.Map<Domain.Models.FlowerDto>(addedFlower)
        };

        return response;
    }
}