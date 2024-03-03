using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public class OrderService : IOrderService
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IBasketRepository _basketRepository;

        public OrderService(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor,
            IBasketRepository basketRepository)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _basketRepository = basketRepository;
        }

        public async Task<OrderEntity> ProcessOrder(AddOrderRequest request, OrderEntity order)
        {
            var items = await GetOrderItems(request.BasketId);
            var deliveryMethod = await GetDeliveryMethod(request.DeliveryMethodId);
            var subtotal = GetSubtotal(items);

            order.DeliveryMethod = deliveryMethod;
            order.OrderItems = items;
            order.Subtotal = subtotal;
            order.BuyerEmail = request.BuyerEmail;
            order.ShipToAddress = request.ShipToAddress;
            order.Invoice = MakeInvoice(order);

            return await CreateOrder(order);
        }

        public async Task<OrderEntity> CreateOrder(OrderEntity order)
        {
            var addOrderCommand = new AddOrderCommand { Parameter = order };

            return await _commandExecutor.Execute(addOrderCommand);
        }

        public async Task<OrderEntity> UpdateOrder(OrderEntity order)
        {
            var updatedOrderCommand = new UpdateOrderCommand { Parameter = order };

            return await _commandExecutor.Execute(updatedOrderCommand);
        }

        public async Task<List<OrderItem>> GetOrderItems(string basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _queryExecutor.Execute(new GetProductQuery { Id = item.Id });
                var orderItem = new OrderItem(
                    new ProductItemOrdered(productItem.Id, productItem.Name, productItem.ImageUrl),
                    productItem.Price,
                    item.Quantity
                );
                items.Add(orderItem);
            }

            await _basketRepository.DeleteBasketAsync(basketId);

            return items;
        }

        public async Task<DeliveryMethod> GetDeliveryMethod(int id)
        {
            return await _queryExecutor.Execute(new GetDeliveryMethodQuery { Id = id });
        }

        public decimal GetSubtotal(IEnumerable<OrderItem> items)
        {
            return items.Sum(item => item.Price * item.Quantity);
        }

        public async Task<List<OrderItem>> GetOrderItemsForUpdate(UpdateOrderRequest request, OrderEntity order)
        {
            var items = new List<OrderItem>();
            foreach (var item in request.OrderItems)
            {
                var productItem = await _queryExecutor.Execute(new GetProductQuery { Id = item.ProductId });
                var orderItem = new OrderItem(
                    new ProductItemOrdered(productItem.Id, productItem.Name, productItem.ImageUrl),
                    productItem.Price,
                    item.Quantity
                );
                items.Add(orderItem);
            }

            return items;
        }

        public async Task<OrderEntity> ProcessUpdateOrder(UpdateOrderRequest request, OrderEntity order)
        {
            var items = await GetOrderItemsForUpdate(request, order);
            var deliveryMethod = await GetDeliveryMethod(request.DeliveryMethodId);
            var subtotal = GetSubtotal(items);

            order.DeliveryMethod = deliveryMethod;
            order.OrderItems = items;
            order.Subtotal = subtotal;
            order.BuyerEmail = request.BuyerEmail;
            order.ShipToAddress = request.ShipToAddress;
            order.Invoice = MakeInvoice(order);

            return await UpdateOrder(order);
        }

        private static string MakeInvoice(OrderEntity order)
        {
            var date = order.CreatedAt.ToString("MM/dd/yyyy");

            return $"{date} {order.BuyerEmail} {order.GetTotal()}";
        }
    }
}