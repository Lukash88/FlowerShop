using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.OrderItem;
using FlowerShop.DataAccess.CQRS.Queries.OrderItem;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public sealed class OrderItemService : IOrderItemService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public OrderItemService(IBasketRepository basketRepository, IQueryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            _basketRepository = basketRepository;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<List<OrderItem>> UpdateOrderItems(UpdateOrderRequest request)
        {
            var itemsToRemove = await GetOrderItems(request.OrderId);
            await RemoveOrderItems(itemsToRemove);

            var newOrderItems = await GenerateOrderItems(request.BasketId);

            return newOrderItems;
        }

        public async Task<List<OrderItem>> GenerateOrderItems(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await _queryExecutor.Execute(new GetProductQuery { Id = item.Id });

                var orderItem = new OrderItem(
                    new ProductItemOrdered(product.Id, product.Name, product.ImageUrl),
                    product.Price,
                    item.Quantity
                );

                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            var getItemsQuery = new GetOrderItemsQuery
            {
                OrderId = orderId
            };

            return await _queryExecutor.Execute(getItemsQuery);
        }

        public async Task<List<OrderItem>> RemoveOrderItems(List<OrderItem> items)
        {
            var removeItemsCommand = new RemoveOrderItemsCommand
            {
                Parameter = items
            };

            return await _commandExecutor.Execute(removeItemsCommand);
        }

        public decimal GetSubtotal(IEnumerable<OrderItem> items)
        {
            return items.Sum(item => item.Price * item.Quantity);
        }
    }
}