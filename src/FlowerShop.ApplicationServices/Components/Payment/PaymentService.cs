using FlowerShop.ApplicationServices.Components.Order;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Payment
{
    public sealed class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly IBasketRepository _basketRepository;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IDeliveryMethodService _deliveryMethodService;
        private readonly IOrderData _orderData;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IConfiguration config, IBasketRepository basketRepository, IQueryExecutor queryExecutor, 
            IDeliveryMethodService deliveryMethodService, IOrderData orderData, ILogger<PaymentService> logger)
        {
            _config = config;
            _basketRepository = basketRepository;
            _queryExecutor = queryExecutor;
            _deliveryMethodService = deliveryMethodService;
            _orderData = orderData;
            _logger = logger;
        }

        public async Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var basket = await _basketRepository.GetBasketAsync(basketId);
            if (basket is null) return null;

            var shippingPrice = await GetShippingPrice(basket.DeliveryMethodId);
            if (shippingPrice == null) return null;

            if (!await UpdateBasketItemsPrices(basket.Items)) return null;

            await CreateOrUpdateIntent(basket, shippingPrice.Value);
            await _basketRepository.UpdateBasketAsync(basket);

            return basket;
        }

        private async Task<decimal?> GetShippingPrice(int? deliveryMethodId)
        {
            if (!deliveryMethodId.HasValue) return 0m;

            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod(deliveryMethodId.Value);
            return deliveryMethod?.Price;
        }

        private async Task<bool> UpdateBasketItemsPrices(List<BasketItem> items)
        {
            foreach (var item in items)
            {
                var productItem = await _queryExecutor.Execute(new GetProductQuery { Id = item.Id });
                if (productItem is null) return false;

                if (item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }
            return true;
        }

        private async Task CreateOrUpdateIntent(CustomerBasket basket, decimal shippingPrice)
        {
            var service = new PaymentIntentService();
            var amount = CalculateTotalAmount(basket.Items, shippingPrice);

            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                var intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions { Amount = amount };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }
        }

        private long CalculateTotalAmount(IEnumerable<BasketItem> items, decimal shippingPrice)
        {
            var itemsTotal = items.Sum(i => i.Quantity * i.Price);
            return (long)((itemsTotal + shippingPrice) * 100);
        }

        public Event ConstructStripeEvent(string json, StringValues stripeSignature)
        {
            try
            {
                return EventUtility.ConstructEvent(json, stripeSignature, _config["StripeSettings:WebHookSecret"]);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to construct Stripe Event");
                throw new StripeException("Invalid signature");
            }
        }

        public async Task<OrderEntity> HandlePaymentIntentSucceeded(PaymentIntent intent)
        {
            var order = await _orderData.GetOrder(intent.Id) ?? throw new Exception("Order not found");
            
            order.OrderState = intent.Status switch
            {
                "succeeded" => (long)(order.GetTotal() * 100) == intent.Amount
                    ? OrderState.PaymentReceived
                    : OrderState.PaymentMismatch,
                "requires_payment_method" => OrderState.PaymentFailed,
                _ => throw new InvalidOperationException($"Unsupported intent status: {intent.Status}")
            };

            order.GetTotal();

            return await _orderData.UpdateOrder(order);
        }
    }
}