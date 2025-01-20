using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Flower;
using FlowerShop.DataAccess.CQRS.Queries.Flower;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower;

public class UpdateFlowerHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    : IRequestHandler<UpdateFlowerRequest, UpdateFlowerResponse>
{
    public async Task<UpdateFlowerResponse> Handle(UpdateFlowerRequest request, CancellationToken cancellationToken)
    {
        var query = new GetFlowerQuery
        {
            Id = request.FlowerId
        };
        var getFlower = await queryExecutor.Execute(query);
        if (getFlower is null)
        {
            return new UpdateFlowerResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedFlower = mapper.Map<DataAccess.Core.Entities.Flower>(request);
        var command = new UpdateFlowerCommand
        { 
            Parameter = mappedFlower 
        };
        var updatedFlower = await commandExecutor.Execute(command);

        var response =  new UpdateFlowerResponse
        {
            Data = mapper.Map<Domain.Models.FlowerDto>(updatedFlower)
        };

        return response;
    }
}