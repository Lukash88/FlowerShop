using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.ApplicationServices.Components.FlowersRecords;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Flower;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower;

public class GetFlowersHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor,
    IFlowersConnector flowersConnector, ILogger<GetFlowersHandler> logger)
    : PagedRequestHandler<GetFlowersRequest, GetFlowersResponse>
{
    public override async Task<GetFlowersResponse> Handle(GetFlowersRequest request, CancellationToken cancellationToken)
    {
        var cutFlowers = await flowersConnector.GetFlowersByType("Cut flowers: ");
        foreach (var flower in cutFlowers)
        {
            logger.LogInformation(flower);
        };

        var query = new GetFlowersQuery
        {
            SieveModel = request.SieveModel
        };

        var flowers = await queryExecutor.ExecuteWithSieve(query);
        if (flowers is null)
        {
            return new GetFlowersResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var results = await flowers.ToPagedAsync<DataAccess.Core.Entities.Flower, FlowerDto>(sieveProcessor, 
            mapper, query.SieveModel, cancellationToken: cancellationToken);
        var response = new GetFlowersResponse
        {
            Data = results
        };

        return response;
    }
}