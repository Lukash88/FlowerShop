using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IOrderData _orderData;
        private readonly IDeliveryMethodService _deliveryMethodService;
        private readonly IOrderItemService _orderItemService;

        public OrderService(IOrderData orderData, DeliveryMethodService deliveryMethodService,
            OrderItemService orderItemService)
        {
            _orderData = orderData;
            _deliveryMethodService = deliveryMethodService;
            _orderItemService = orderItemService;
        }

        public async Task<OrderEntity> ProcessOrder(AddOrderRequest request, OrderEntity order)
        {
            var items = await _orderItemService.GetOrderItems(request.BasketId);
            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
            var subtotal = _orderItemService.GetSubtotal(items);

            SetOrderProperties(order, items, deliveryMethod, subtotal, request.BuyerEmail, request.ShipToAddress);

            return await _orderData.CreateOrder(order);
        }

        public async Task<OrderEntity> ProcessUpdateOrder(UpdateOrderRequest request, OrderEntity order)
        {
            var items = await _orderItemService.GetOrderItemsForUpdate(request, order);
            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
            var subtotal = _orderItemService.GetSubtotal(items);

            SetOrderProperties(order, items, deliveryMethod, subtotal, request.BuyerEmail, request.ShipToAddress);

            return await _orderData.UpdateOrder(order);
        }

        private void SetOrderProperties(OrderEntity order, List<OrderItem> items, DeliveryMethod deliveryMethod,
            decimal subtotal, string buyerEmail, Address shipToAddress)
        {
            order.DeliveryMethod = deliveryMethod;
            order.OrderItems = items;
            order.Subtotal = subtotal;
            order.BuyerEmail = buyerEmail;
            order.ShipToAddress = shipToAddress;
            order.Invoice = MakeInvoice(order);
        }

        private static string MakeInvoice(OrderEntity order)
        {
            var date = order.CreatedAt.ToString("MM/dd/yyyy");

            return $"{date} {order.BuyerEmail} {order.GetTotal()}";
        }
    }
}