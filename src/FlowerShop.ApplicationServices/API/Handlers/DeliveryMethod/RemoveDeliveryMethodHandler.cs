using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod;

public class RemoveDeliveryMethodHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    : IRequestHandler<RemoveDeliveryMethodRequest, RemoveDeliveryMethodResponse>
{
    public async Task<RemoveDeliveryMethodResponse> Handle(RemoveDeliveryMethodRequest request, 
        CancellationToken cancellationToken)
    {
        var query = new GetDeliveryMethodQuery
        {
            Id = request.MethodId
        };
        var getDeliveryMethod = await queryExecutor.Execute(query);
        if (getDeliveryMethod is null)
        {
            return new RemoveDeliveryMethodResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedDeliveryMethod = mapper.Map<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod>(request);
        var command = new RemoveDeliveryMethodCommand
        {
            Parameter = mappedDeliveryMethod
        };
        var removedDeliveryMethod = await commandExecutor.Execute(command);
        var response = new RemoveDeliveryMethodResponse
        {
            Data = mapper.Map<DeliveryMethodDto>(removedDeliveryMethod)
        };

        return response;
    }
}