using FlowerShop.ApplicationServices.Components.Order;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.CartRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Stripe;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Payment;

public sealed class PaymentService(IConfiguration config, ICartRepository cartRepository,
    IQueryExecutor queryExecutor, IDeliveryMethodService deliveryMethodService,
    IOrderData orderData, ILogger<PaymentService> logger) : IPaymentService
{
    public async Task<ShoppingCart?> CreateOrUpdatePaymentIntent(string cartId)
    {
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];
        var cart = await cartRepository.GetCartAsync(cartId);
        if (cart is null) return null;

        var shippingPrice = await GetShippingPrice(cart.DeliveryMethodId);
        if (shippingPrice is null) return null;

        if (!await UpdateCartItemsPrices(cart.Items)) return null;

        await CreateOrUpdateIntent(cart, shippingPrice.Value);
        await cartRepository.UpdateCartAsync(cart);

        return cart;
    }

    private async Task<decimal?> GetShippingPrice(int? deliveryMethodId)
    {
        if (!deliveryMethodId.HasValue) return 0m;

        var deliveryMethod = await deliveryMethodService.GetDeliveryMethod(deliveryMethodId.Value);
        return deliveryMethod?.Price;
    }

    private async Task<bool> UpdateCartItemsPrices(List<CartItem> items)
    {
        foreach (var item in items)
        {
            var productItem = await queryExecutor.Execute(new GetProductQuery { Id = item.ProductId });
            if (productItem is null) return false;

            if (item.Price != productItem.Price)
            {
                item.Price = productItem.Price;
            }
        }
        return true;
    }

    private async Task CreateOrUpdateIntent(ShoppingCart cart, decimal shippingPrice)
    {
        var service = new PaymentIntentService();
        var amount = CalculateTotalAmount(cart.Items, shippingPrice);

        if (string.IsNullOrEmpty(cart.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = "usd",
                PaymentMethodTypes = ["card"]
            };

            var intent = await service.CreateAsync(options);
            cart.PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;
        }
        else
        {
            var options = new PaymentIntentUpdateOptions { Amount = amount };
            await service.UpdateAsync(cart.PaymentIntentId, options);
        }
    }

    private static long CalculateTotalAmount(IEnumerable<CartItem> items, decimal shippingPrice)
    {
        var itemsTotal = items.Sum(i => i.Quantity * i.Price);
        return (long)((itemsTotal + shippingPrice) * 100);
    }

    public Event ConstructStripeEvent(string json, StringValues stripeSignature)
    {
        try
        {
            return EventUtility.ConstructEvent(json, stripeSignature, config["StripeSettings:WebHookSecret"]);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to construct Stripe Event");
            throw new StripeException("Invalid signature");
        }
    }

    public async Task<OrderEntity> HandlePaymentIntentSucceeded(PaymentIntent intent)
    {
        var order = await orderData.GetOrder(intent.Id) ?? throw new Exception("Order not found");
            
        order.OrderState = intent.Status switch
        {
            "succeeded" => (long)(order.GetTotal() * 100) == intent.Amount
                ? OrderState.PaymentReceived
                : OrderState.PaymentMismatch,
            "requires_payment_method" => OrderState.PaymentFailed,
            _ => throw new InvalidOperationException($"Unsupported intent status: {intent.Status}")
        };

        order.GetTotal();

        return await orderData.UpdateOrder(order);
    }
}