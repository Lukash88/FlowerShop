using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Core.Enums;
using FlowerShop.DataAccess.Repositories.CartRepository;
using Microsoft.Extensions.Logging;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class OrderService(
    IMapper mapper,
    IOrderData orderData,
    IDeliveryMethodService deliveryMethodService,
    IOrderItemService orderItemService,
    ICartRepository cartRepository,
    ILogger<OrderService> logger) : IOrderService
{
    public async Task<OrderEntity> ProcessOrderRequest(AddOrderRequest request)
    {
        logger.LogInformation("Processing order for CartId: {CartId}", request.CartId);

        var cart = await cartRepository.GetCartAsync(request.CartId);

        if (cart is null)
        {
            throw new InvalidOperationException($"Cart with id {request.CartId} not found");
        }

        logger.LogInformation("Cart found. PaymentIntentId: {PaymentIntentId}", cart.PaymentIntentId);

        if (string.IsNullOrEmpty(cart.PaymentIntentId))
        {
            logger.LogWarning("PaymentIntentId is null for cart {CartId}. Creating new order.", request.CartId);
            return await ProcessNewOrderRequest(request, cart);
        }

        var existingOrder = await orderData.GetOrder(cart.PaymentIntentId);

        if (existingOrder is not null)
        {
            logger.LogInformation("Existing order {OrderId} found with state {State}",
                existingOrder.Id, existingOrder.OrderState);

            if (existingOrder.OrderState == OrderState.PaymentReceived)
            {
                throw new InvalidOperationException("Order has already been paid");
            }

            if (existingOrder.OrderState == OrderState.Pending)
            {
                logger.LogInformation("Returning existing pending order {OrderId}", existingOrder.Id);
                return existingOrder;
            }

            if (existingOrder.OrderState == OrderState.PaymentFailed)
            {
                logger.LogInformation("Order {OrderId} was PaymentFailed. Re-reducing stock.", existingOrder.Id);
                return await ProcessRetryAfterFailure(existingOrder, request);
            }
        }

        return await ProcessNewOrderRequest(request, cart);
    }

    private async Task<OrderEntity> ProcessRetryAfterFailure(OrderEntity existingOrder, AddOrderRequest request)
    {
        await orderItemService.AdjustStockForOrder(existingOrder, StockAdjustmentType.Reduce);

        var updatedOrder = new OrderEntity
        {
            Id = existingOrder.Id,
            BuyerEmail = existingOrder.BuyerEmail,
            CreatedAt = existingOrder.CreatedAt,
            ShippingAddress = existingOrder.ShippingAddress,
            DeliveryMethod = existingOrder.DeliveryMethod,
            PaymentSummary = existingOrder.PaymentSummary,
            Subtotal = existingOrder.Subtotal,
            Discount = existingOrder.Discount,
            OrderState = OrderState.Pending,
            Invoice = existingOrder.Invoice,
            PaymentIntentId = existingOrder.PaymentIntentId,
            OrderItems = existingOrder.OrderItems,
            Reservations = existingOrder.Reservations
        };

        logger.LogInformation("Updating order {OrderId} state to Pending for retry", updatedOrder.Id);
        return await orderData.UpdateOrder(updatedOrder);
    }

    private async Task<OrderEntity> ProcessNewOrderRequest(AddOrderRequest request, ShoppingCart cart)
    {
        logger.LogInformation("Creating new order for cart {CartId}", request.CartId);

        var items = await orderItemService.GenerateOrderItems(request.CartId);
        var deliveryMethod = await deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
        var subtotal = orderItemService.GetSubtotal(items);

        request.OrderItems = mapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
        request.Subtotal = subtotal;
        request.PaymentIntentId = cart.PaymentIntentId;

        var order = mapper.Map<OrderEntity>(request);
        order.DeliveryMethod = deliveryMethod;
        order.Invoice = MakeInvoice(order);

        var createdOrder = await orderData.CreateOrder(order);
        logger.LogInformation("Created new order {OrderId}", createdOrder.Id);

        return createdOrder;
    }

    public async Task<OrderEntity> ProcessUpdateOrderRequest(UpdateOrderRequest request)
    {
        var items = await orderItemService.UpdateOrderItems(request);
        request.OrderItems = mapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
        request.Subtotal = orderItemService.GetSubtotal(items);

        var order = mapper.Map<OrderEntity>(request);
        order.DeliveryMethod = await deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);

        return await orderData.UpdateOrder(order);
    }

    private static string MakeInvoice(OrderEntity order)
    {
        var date = order.CreatedAt.ToString("MM/dd/yyyy");

        return $"{date} {order.BuyerEmail} {order.GetTotal()}";
    }
}