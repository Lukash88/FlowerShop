using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet;

public class AddBouquetHandler(ICommandExecutor commandExecutor, IMapper mapper)
    : IRequestHandler<AddBouquetRequest, AddBouquetResponse>
{
    public async Task<AddBouquetResponse> Handle(AddBouquetRequest request, CancellationToken cancellationToken)
    {
        var bouquet = mapper.Map<DataAccess.Core.Entities.Bouquet>(request);
        var command = new AddBouquetCommand
        {
            Parameter = bouquet
        };
        var addedBouquet = await commandExecutor.Execute(command);
        var response = new AddBouquetResponse
        {
            Data = mapper.Map<BouquetDto>(addedBouquet)
        };

        return response;
    }
}