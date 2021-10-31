namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderItem;
    using MediatR;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateOrderItemHandler : IRequestHandler<UpdateOrderItemRequest, UpdateOrderItemResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateOrderItemHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateOrderItemResponse> Handle(UpdateOrderItemRequest request, CancellationToken cancellationToken)
        {
            var orderItem = this.mapper.Map<DataAccess.Entities.OrderItem>(request);
            var command = new UpdateOrderItemCommand()
            {
                Parameter = orderItem
            };
            var orderItemFromDb = await this.commandExecutor.Execute(command);

            return new UpdateOrderItemResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderItemDTO>(orderItemFromDb)
            };
        }
    }
}
