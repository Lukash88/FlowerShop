using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public sealed class OrderItemService : IOrderItemService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IQueryExecutor _queryExecutor;

        public OrderItemService(IBasketRepository basketRepository, IQueryExecutor queryExecutor)
        {
            _basketRepository = basketRepository;
            _queryExecutor = queryExecutor;
        }

        public async Task<List<OrderItem>> GetOrderItems(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            var items = await CreateOrderItems(basket.Items.Select(i => (i.Id, i.Quantity)));
            await _basketRepository.DeleteBasketAsync(basketId);
            return items;
        }

        public async Task<List<OrderItem>> GetOrderItemsForUpdate(UpdateOrderRequest request, OrderEntity order)
        {
            var items = await CreateOrderItems(request.OrderItems.Select(i => (i.ProductId, i.Quantity)));
            return items;
        }

        private async Task<List<OrderItem>> CreateOrderItems(IEnumerable<(int ProductId, int Quantity)> items)
        {
            var orderItems = new List<OrderItem>();
            foreach (var item in items)
            {
                var productItem = await _queryExecutor.Execute(new GetProductQuery { Id = item.ProductId });
                var orderItem = new OrderItem(
                    new ProductItemOrdered(productItem.Id, productItem.Name, productItem.ImageUrl),
                    productItem.Price,
                    item.Quantity
                );
                orderItems.Add(orderItem);
            }

            return orderItems;
        }

        public decimal GetSubtotal(IEnumerable<OrderItem> items)
        {
            return items.Sum(item => item.Price * item.Quantity);
        }
    }
}