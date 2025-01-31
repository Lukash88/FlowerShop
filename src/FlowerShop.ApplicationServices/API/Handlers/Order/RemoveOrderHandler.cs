using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Order;

public class RemoveOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    : IRequestHandler<RemoveOrderRequest, RemoveOrderResponse>
{
    public async Task<RemoveOrderResponse> Handle(RemoveOrderRequest request, CancellationToken cancellationToken)
    {
        var query = new GetOrderQuery
        {
            Id = request.OrderId
        };
        var getOrder = await queryExecutor.Execute(query);
        if (getOrder is null)
        {
            return new RemoveOrderResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedOrder = mapper.Map<DataAccess.Core.Entities.OrderAggregate.Order>(request);
        var command = new RemoveOrderCommand
        {
            Parameter = mappedOrder
        };
        var removedOrder = await commandExecutor.Execute(command);
            
        var response = new RemoveOrderResponse
        {
            Data = mapper.Map<Domain.Models.OrderToReturnDto>(removedOrder)
        };

        return response;
    }
}