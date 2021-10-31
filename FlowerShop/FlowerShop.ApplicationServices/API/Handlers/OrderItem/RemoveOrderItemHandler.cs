namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderItem;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveOrderItemHandler : IRequestHandler<RemoveOrderItemRequest, RemoveOrderItemResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveOrderItemHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<RemoveOrderItemResponse> Handle(RemoveOrderItemRequest request, CancellationToken cancellationToken)
        {
            var orderItem = mapper.Map<OrderItem>(request);
            var command = new RemoveOrderItemCommand()
            {
                Parameter = orderItem
            };
            await this.commandExecutor.Execute(command);
            var response = new RemoveOrderItemResponse()
            {
                Data = null
            };

            return response;
        }
    }
}
