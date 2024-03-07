using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class RemoveOrderHandler : IRequestHandler<RemoveOrderRequest, RemoveOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public RemoveOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        public async Task<RemoveOrderResponse> Handle(RemoveOrderRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery()
            {
                Id = request.OrderId
            };
            var getOrder = await _queryExecutor.Execute(query);
            if (getOrder is null)
            {
                return new RemoveOrderResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrder = _mapper.Map<DataAccess.Core.Entities.OrderAggregate.Order>(request);
            var command = new RemoveOrderCommand()
            {
                Parameter = mappedOrder
            };
            var removedOrder = await _commandExecutor.Execute(command);
            removedOrder.DeliveryMethod = new();
            
            var response = new RemoveOrderResponse()
            {
                Data = _mapper.Map<Domain.Models.OrderToReturnDto>(removedOrder)
            };

            return response;
        }
    }
}