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

public class UpdateBouquetHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    : IRequestHandler<UpdateBouquetRequest, UpdateBouquetResponse>
{
    public async Task<UpdateBouquetResponse> Handle(UpdateBouquetRequest request, CancellationToken cancellationToken)
    {
        var query = new GetBouquetQuery
        {
            Id = request.BouquetId
        };
        var getBouquet = await queryExecutor.Execute(query);
        if (getBouquet is null)
        {
            return new UpdateBouquetResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedBouquet = mapper.Map<DataAccess.Core.Entities.Bouquet>(request);
        var command = new UpdateBouquetCommand
        {
            Parameter = mappedBouquet
        };
        var updatedBouquet = await commandExecutor.Execute(command);
        var response = new UpdateBouquetResponse
        {
            Data = mapper.Map<BouquetDto>(updatedBouquet)
        };

        return response;
    }
}