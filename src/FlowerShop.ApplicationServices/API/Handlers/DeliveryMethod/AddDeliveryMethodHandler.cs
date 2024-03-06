using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod
{
    public class AddDeliveryMethodHandler : IRequestHandler<AddDeliveryMethodRequest, AddDeliveryMethodResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddDeliveryMethodHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddDeliveryMethodResponse> Handle(AddDeliveryMethodRequest request,
            CancellationToken cancellationToken)
        {
            var deliveryMethod = this.mapper.Map<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod>(request);
            var command = new AddDeliveryMethodCommand()
            {
                Parameter = deliveryMethod
            };
            var addedDeliveryMethod = await this.commandExecutor.Execute(command);
            var response = new AddDeliveryMethodResponse()
            {
                Data = this.mapper.Map<DeliveryMethodDto>(addedDeliveryMethod)
            };

            return response;
        }
    }
}