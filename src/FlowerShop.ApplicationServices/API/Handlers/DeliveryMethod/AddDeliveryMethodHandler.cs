using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod
{
    public class AddDeliveryMethodHandler : IRequestHandler<AddDeliveryMethodRequest, AddDeliveryMethodResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddDeliveryMethodHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddDeliveryMethodResponse> Handle(AddDeliveryMethodRequest request,
            CancellationToken cancellationToken)
        {
            var deliveryMethod = _mapper.Map<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod>(request);
            var command = new AddDeliveryMethodCommand()
            {
                Parameter = deliveryMethod
            };
            var addedDeliveryMethod = await _commandExecutor.Execute(command);
            var response = new AddDeliveryMethodResponse()
            {
                Data = _mapper.Map<DeliveryMethodDto>(addedDeliveryMethod)
            };

            return response;
        }
    }
}