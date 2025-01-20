using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using Microsoft.Extensions.Logging;
using Sieve.Services;
using ProductEntity = FlowerShop.DataAccess.Core.Entities.Product;

namespace FlowerShop.ApplicationServices.API.Handlers.Product;

public class GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor,
    ILogger<GetProductsHandler> logger) : PagedRequestHandler<GetProductsRequest, GetProductsResponse>
{
    public override async Task<GetProductsResponse> Handle(GetProductsRequest request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting a list of Products");

        var query = new GetProductsQuery
        {
            SieveModel = request.SieveModel
        };

        var products = await queryExecutor.ExecuteWithSieve(query);
        if (products is null)
        {
            return new GetProductsResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }          

        var results = await products.ToPagedAsync<ProductEntity, ProductDto>(sieveProcessor, 
            mapper, query.SieveModel, cancellationToken: cancellationToken);
        var response = new GetProductsResponse
        { 
            Data = results 
        };

        return response;
    }
}