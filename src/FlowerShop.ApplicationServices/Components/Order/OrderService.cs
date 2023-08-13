using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public class OrderService : IOrderService
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IBasketRepository basketRepository;

        public OrderService(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor,
            IBasketRepository basketRepository)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.basketRepository = basketRepository;
        }


        public async Task<List<OrderItem>> GetOrderItems(string basketId)
        {
            // get basket from the repo
            var basket = await this.basketRepository.GetBasketAsync(basketId);

            // get items from the product repo  
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productQuery = new GetProductQuery()
                {
                    Id = item.Id
                };
                var productItem = await this.queryExecutor.Execute(productQuery);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.ImageUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price,
                    item.Quantity);
                items.Add(orderItem);
            }

            // delete basket
            await this.basketRepository.DeleteBasketAsync(basketId);

            return items;
        }

        public async Task<DataAccess.Core.Entities.OrderAggregate.Order> CreateOrder(
            DataAccess.Core.Entities.OrderAggregate.Order order,
            DeliveryMethod deliveryMethod, List<OrderItem> items, decimal subtotal, string email,
            Address shippingAddress)
        {
            order.DeliveryMethod = deliveryMethod;
            order.OrderItems = items;
            order.Subtotal = subtotal;
            order.BuyerEmail = email;
            order.ShipToAddress = shippingAddress;
            order.Invoice = MakeInvoice(order);

            var oderCommand = new AddOrderCommand()
            {
                Parameter = order
            };
            var addedOrder = await this.commandExecutor.Execute(oderCommand);

            return addedOrder;
        }

        public decimal GetSubtotal(List<OrderItem> items)
        {
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            return subtotal;
        }

        public async Task<DeliveryMethod> GetDeliveryMethod(int id)
        {
            var deliveryMethodQuery = new GetDeliveryMethodQuery()
            {
                Id = id
            };
            var deliveryMethod = await this.queryExecutor.Execute(deliveryMethodQuery);

            return deliveryMethod;
        }

        private static string MakeInvoice(DataAccess.Core.Entities.OrderAggregate.Order order)
        {
            var date = order.CreatedAt.ToString("MM/dd/yyyy");

            return date + " " + order.BuyerEmail + " " + order.GetTotal();
        }
    }
}