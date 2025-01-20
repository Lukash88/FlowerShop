using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod;

public class AddDeliveryMethodHandler(ICommandExecutor commandExecutor, IMapper mapper)
    : IRequestHandler<AddDeliveryMethodRequest, AddDeliveryMethodResponse>
{
    public async Task<AddDeliveryMethodResponse> Handle(AddDeliveryMethodRequest request,
        CancellationToken cancellationToken)
    {
        var deliveryMethod = mapper.Map<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod>(request);
        var command = new AddDeliveryMethodCommand
        {
            Parameter = deliveryMethod
        };
        var addedDeliveryMethod = await commandExecutor.Execute(command);
        var response = new AddDeliveryMethodResponse
        {
            Data = mapper.Map<DeliveryMethodDto>(addedDeliveryMethod)
        };

        return response;
    }
}