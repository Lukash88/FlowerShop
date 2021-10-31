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

    public class AddOrderItemHandler : IRequestHandler<AddOrderItemRequest, AddOrderItemResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddOrderItemHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddOrderItemResponse> Handle(AddOrderItemRequest request, CancellationToken cancellationToken)
        {
            var orderItem = this.mapper.Map<OrderItem>(request);
            var command = new AddOrderItemCommand() { Parameter = orderItem };
            var orderItemFromDb = await this.commandExecutor.Execute(command);

            return new AddOrderItemResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderItemDTO>(orderItemFromDb)
            };
        }
    }
}
