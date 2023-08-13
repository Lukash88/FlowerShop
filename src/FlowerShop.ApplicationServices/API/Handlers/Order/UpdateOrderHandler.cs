using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class UpdateOrderHandler  : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery()
            {
                Id = request.OrderId
            };
            var getOrder = await this.queryExecutor.Execute(query);
            if (getOrder is null)
            {
                return new UpdateOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrder = this.mapper.Map<DataAccess.Core.Entities.OrderAggregate.Order>(request);
            var command = new UpdateOrderCommand()
            {
                Parameter = mappedOrder
            };
            var updatedOrder = await this.commandExecutor.Execute(command);
            var response = new UpdateOrderResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderToReturnDto>(updatedOrder)
            };

            return response;
        }
    }
}