using System.Threading.Tasks;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    internal sealed class OrderData : IOrderData
    {
        private readonly ICommandExecutor _commandExecutor;

        public OrderData(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        public async Task<OrderEntity> CreateOrder(OrderEntity order)
        {
            var addOrderCommand = new AddOrderCommand { Parameter = order };
            return await _commandExecutor.Execute(addOrderCommand);
        }

        public async Task<OrderEntity> UpdateOrder(OrderEntity order)
        {
            var updateOrderCommand = new UpdateOrderCommand { Parameter = order };
            return await _commandExecutor.Execute(updateOrderCommand);
        }
    }
}