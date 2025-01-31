using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order;

public sealed class OrderService(IMapper mapper, IOrderData orderData, IDeliveryMethodService deliveryMethodService,
    IOrderItemService orderItemService, IBasketRepository basketRepository) : IOrderService
{
    public async Task<OrderEntity> ProcessOrderRequest(AddOrderRequest request)
    {
        var basket = await basketRepository.GetBasketAsync(request.BasketId);
        var getOrder = await orderData.GetOrder(basket.PaymentIntentId);

        if (getOrder is not null)
        {
            var updateOrderRequest = mapper.Map<UpdateOrderRequest>(getOrder);
            updateOrderRequest.BasketId = request.BasketId;
            return await ProcessUpdateOrder(updateOrderRequest);
        }

        return await ProcessNewOrderRequest(request, basket);
    }

    private async Task<OrderEntity> ProcessNewOrderRequest(AddOrderRequest request, CustomerBasket basket)
    {
        var items = await orderItemService.GenerateOrderItems(request.BasketId);
        var deliveryMethod = await deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
        var subtotal = orderItemService.GetSubtotal(items);

        request.OrderItems = mapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
        request.Subtotal = subtotal;
        request.PaymentIntentId = basket.PaymentIntentId;

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