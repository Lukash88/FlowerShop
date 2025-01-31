using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet;

public class RemoveBouquetHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    : IRequestHandler<RemoveBouquetRequest, RemoveBouquetResponse>
{
    public async Task<RemoveBouquetResponse> Handle(RemoveBouquetRequest request, CancellationToken cancellationToken)
    {
        var query = new GetBouquetQuery
        {
            Id = request.BouquetId
        };
        var getBouquet = await queryExecutor.Execute(query);
        if (getBouquet is null)
        {
            return new RemoveBouquetResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedBouquet = mapper.Map<DataAccess.Core.Entities.Bouquet>(request);
        var command = new RemoveBouquetCommand
        {
            Parameter = mappedBouquet
        };
        var removedBouquet = await commandExecutor.Execute(command);
        var response = new RemoveBouquetResponse
        {
            Data = mapper.Map<BouquetDto>(removedBouquet)
        };

        return response;
    }
}