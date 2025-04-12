using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Repositories.CartRepository;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class OrderService(IMapper mapper, IOrderData orderData, IDeliveryMethodService deliveryMethodService,
    IOrderItemService orderItemService, ICartRepository cartRepository) : IOrderService
{
    public async Task<OrderEntity> ProcessOrderRequest(AddOrderRequest request)
    {
        var cart = await cartRepository.GetCartAsync(request.CartId);
        var getOrder = await orderData.GetOrder(cart.PaymentIntentId);

        if (getOrder is not null)
        {
            var updateOrderRequest = mapper.Map<UpdateOrderRequest>(getOrder);
            updateOrderRequest.CartId = request.CartId;
            return await ProcessUpdateOrder(updateOrderRequest);
        }

        return await ProcessNewOrderRequest(request, cart);
    }

    private async Task<OrderEntity> ProcessNewOrderRequest(AddOrderRequest request, ShoppingCart cart)
    {
        var items = await orderItemService.GenerateOrderItems(request.CartId);
        var deliveryMethod = await deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
        var subtotal = orderItemService.GetSubtotal(items);

        request.OrderItems = mapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
        request.Subtotal = subtotal;
        request.PaymentIntentId = cart.PaymentIntentId;

        var order = mapper.Map<OrderEntity>(request);
        order.DeliveryMethod = deliveryMethod;
        order.Invoice = MakeInvoice(order);

        return await orderData.CreateOrder(order);
    }

    private async Task<OrderEntity> ProcessUpdateOrder(UpdateOrderRequest request)
    {
        var items = await orderItemService.UpdateOrderItems(request);
        var deliveryMethod = await deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
        var subtotal = orderItemService.GetSubtotal(items);

        request.OrderItems = mapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
        request.Subtotal = subtotal;

        var order = mapper.Map<OrderEntity>(request);
        order.DeliveryMethod = deliveryMethod;

        return await orderData.UpdateOrder(order);
    }

    public async Task<OrderEntity> ProcessUpdateOrderRequest(UpdateOrderRequest request)
    {
        var items = await orderItemService.UpdateOrderItems(request);
        var deliveryMethod = await deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
        var subtotal = orderItemService.GetSubtotal(items);

        request.OrderItems = mapper.Map<List<OrderItem>, List<OrderItemDto>>(items); ;
        request.Subtotal = subtotal;

        var order = mapper.Map<OrderEntity>(request);
        order.DeliveryMethod = deliveryMethod;

        return await orderData.UpdateOrder(order);
    }

    private static string MakeInvoice(OrderEntity order)
    {
        var date = order.CreatedAt.ToString("MM/dd/yyyy");

        return $"{date} {order.BuyerEmail} {order.GetTotal()}";
    }
}