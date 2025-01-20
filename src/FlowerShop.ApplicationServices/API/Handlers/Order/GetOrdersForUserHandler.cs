using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using Microsoft.Extensions.Logging;
using Sieve.Services;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.API.Handlers.Order;

public class GetOrdersForUserHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor,
    ILogger<GetOrdersHandler> logger) : PagedRequestHandler<GetOrdersForUserRequest, GetOrdersResponse>
{
    public override async Task<GetOrdersResponse> Handle(GetOrdersForUserRequest request, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting a list of User Orders");

        var query = new GetOrdersForUserQuery
        {
            Email = request.Email,
            SieveModel = request.SieveModel
        };

        var orders = await queryExecutor.ExecuteWithSieve(query);
        if (orders is null)
        {
            return new GetOrdersResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var results = await orders.ToPagedAsync<OrderEntity,
            OrderToReturnDto>(sieveProcessor, mapper, query.SieveModel, cancellationToken: cancellationToken);
        var response = new GetOrdersResponse
        {
            Data = results
        };

        return response;
    }
}