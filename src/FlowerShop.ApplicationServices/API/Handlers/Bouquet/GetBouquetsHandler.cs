using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet;

public class GetBouquetsHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor,
    ILogger<GetBouquetsHandler> logger) : PagedRequestHandler<GetBouquetsRequest, GetBouquetsResponse>
{
    public override async Task<GetBouquetsResponse> Handle(GetBouquetsRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting a list of Bouquets");

        var query = new GetBouquetsQuery
        {
            SieveModel = request.SieveModel
        };

        var bouquets = await queryExecutor.ExecuteWithSieve(query);
        if (bouquets is null)
        {
            return new GetBouquetsResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var results = await bouquets.ToPagedAsync<DataAccess.Core.Entities.Bouquet, BouquetDto>(sieveProcessor,
            mapper, query.SieveModel, cancellationToken: cancellationToken);
        var response = new GetBouquetsResponse
        {
            Data = results
        };

        return response;
    }
}