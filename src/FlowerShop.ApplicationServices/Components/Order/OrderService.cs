using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public sealed class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderData _orderData;
        private readonly IDeliveryMethodService _deliveryMethodService;
        private readonly IOrderItemService _orderItemService;
        private readonly IBasketRepository _basketRepository;

        public OrderService(IMapper mapper, IOrderData orderData, IDeliveryMethodService deliveryMethodService,
            IOrderItemService orderItemService, IBasketRepository basketRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _orderData = orderData;
            _deliveryMethodService = deliveryMethodService;
            _orderItemService = orderItemService;
        }
        
        public async Task<OrderEntity> ProcessOrderRequest(AddOrderRequest request)
        {
            var basket = await _basketRepository.GetBasketAsync(request.BasketId);
            var getOrder = await _orderData.GetOrder(basket.PaymentIntentId);

            if (getOrder is not null)
            {
                var updateOrderRequest = _mapper.Map<UpdateOrderRequest>(getOrder);
                updateOrderRequest.BasketId = request.BasketId;
                return await ProcessUpdateOrder(updateOrderRequest);
            }

            return await ProcessNewOrderRequest(request, basket);
        }

        private async Task<OrderEntity> ProcessNewOrderRequest(AddOrderRequest request, CustomerBasket basket)
        {
            var items = await _orderItemService.GenerateOrderItems(request.BasketId);
            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
            var subtotal = _orderItemService.GetSubtotal(items);

            request.OrderItems = _mapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
            request.Subtotal = subtotal;
            request.PaymentIntentId = basket.PaymentIntentId;

            var order = _mapper.Map<OrderEntity>(request);
            order.DeliveryMethod = deliveryMethod;
            order.Invoice = MakeInvoice(order);

            return await _orderData.CreateOrder(order);
        }

        private async Task<OrderEntity> ProcessUpdateOrder(UpdateOrderRequest request)
        {
            var items = await _orderItemService.UpdateOrderItems(request);
            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
            var subtotal = _orderItemService.GetSubtotal(items);

            request.OrderItems = _mapper.Map<List<OrderItem>, List<OrderItemDto>>(items);
            request.Subtotal = subtotal;

            var order = _mapper.Map<OrderEntity>(request);
            order.DeliveryMethod = deliveryMethod;

            return await _orderData.UpdateOrder(order);
        }

        public async Task<OrderEntity> ProcessUpdateOrderRequest(UpdateOrderRequest request)
        {
            var items = await _orderItemService.UpdateOrderItems(request);
            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod(request.DeliveryMethodId);
            var subtotal = _orderItemService.GetSubtotal(items);

            request.OrderItems = _mapper.Map<List<OrderItem>, List<OrderItemDto>>(items); ;
            request.Subtotal = subtotal;

            var order = _mapper.Map<OrderEntity>(request);
            order.DeliveryMethod = deliveryMethod;

            return await _orderData.UpdateOrder(order);
        }

        private static string MakeInvoice(OrderEntity order)
        {
            var date = order.CreatedAt.ToString("MM/dd/yyyy");

            return $"{date} {order.BuyerEmail} {order.GetTotal()}";
        }
    }
}