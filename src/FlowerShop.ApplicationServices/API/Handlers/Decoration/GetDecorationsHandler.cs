using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Decoration;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration;

public class GetDecorationsHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor,
    ILogger<GetDecorationsHandler> logger) : PagedRequestHandler<GetDecorationsRequest, GetDecorationsResponse>
{
    public override async Task<GetDecorationsResponse> Handle(GetDecorationsRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting a list of Decorations");

        var query = new GetDecorationsQuery
        {
            SieveModel = request.SieveModel
        };

        var decorations = await queryExecutor.ExecuteWithSieve(query);
        if (decorations is null)
        {
            return new GetDecorationsResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var results = await decorations.ToPagedAsync<DataAccess.Core.Entities.Decoration, DecorationDto>(sieveProcessor, 
            mapper, query.SieveModel, cancellationToken: cancellationToken);
        var response = new GetDecorationsResponse
        {
            Data = results
        };

        return response;
    }
}