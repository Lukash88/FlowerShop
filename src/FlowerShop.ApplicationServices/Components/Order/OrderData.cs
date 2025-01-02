using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public sealed class OrderData : IOrderData
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public OrderData(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        public async Task<OrderEntity> GetOrder(string paymentIntentId)
        {
            var getOrderQuery = new GetOrderByPaymentIntentIdQuery
            {
                Id = paymentIntentId
            };

            return await _queryExecutor.Execute(getOrderQuery);
        }

        public async Task<OrderEntity> CreateOrder(OrderEntity order)
        {
            var addOrderCommand = new AddOrderCommand
            {
                Parameter = order
            };

            return await _commandExecutor.Execute(addOrderCommand);
        }

        public async Task<OrderEntity> UpdateOrder(OrderEntity order)
        {
            var updateOrderCommand = new UpdateOrderCommand
            {
                Parameter = order
            };

            return await _commandExecutor.Execute(updateOrderCommand);
        }
    }
}