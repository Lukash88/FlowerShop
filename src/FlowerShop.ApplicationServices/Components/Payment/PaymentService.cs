using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerShop.ApplicationServices.Components.Order;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace FlowerShop.ApplicationServices.Components.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly IBasketRepository _basketRepository;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IDeliveryMethodService _deliveryMethodService;

        public PaymentService(IConfiguration config, IBasketRepository basketRepository, IQueryExecutor queryExecutor, 
            ICommandExecutor commandExecutor, IDeliveryMethodService deliveryMethodService)
        {
            _config = config;
            _basketRepository = basketRepository;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
            _deliveryMethodService = deliveryMethodService;
        }

        public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            var basket = await _basketRepository.GetBasketAsync(basketId);
            var shippingPrice = 0m;

            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod((int)basket.DeliveryMethodId);
                shippingPrice = deliveryMethod.Price;
            }

            foreach (var item in basket.Items)
            {
                var productItem = await _queryExecutor.Execute(new GetProductQuery() { Id = item.Id });
                if (item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            var service = new PaymentIntentService();

            PaymentIntent intent;

            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions()
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100
                };
                intent = await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            await _basketRepository.UpdateBasketAsync(basket);

            return basket;
        }
    }
}