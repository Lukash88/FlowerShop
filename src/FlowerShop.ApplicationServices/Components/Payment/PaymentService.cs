using FlowerShop.ApplicationServices.Components.Order;
using FlowerShop.ApplicationServices.Components.SignalR;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Core.Enums;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using FlowerShop.DataAccess.Repositories.CartRepository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Stripe;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Payment;

public sealed class PaymentService(
    IConfiguration config,
    ICartRepository cartRepository,
    IQueryExecutor queryExecutor,
    IDeliveryMethodService deliveryMethodService,
    IOrderData orderData,
    IHubContext<NotificationHub> hubContext,
    ILogger<PaymentService> logger) : IPaymentService
{
    public async Task<ShoppingCart?> CreateOrUpdatePaymentIntent(string cartId)
    {
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];

        var cart = await cartRepository.GetCartAsync(cartId) ?? throw new Exception("Cart unavailable");
        var shippingPrice = await GetShippingPriceInCents(cart.DeliveryMethodId) ?? 0;

        await UpdateCartItemsPrices(cart.Items);

        var subtotal = CalculateSubtotal(cart);

        if (cart.Coupon != null)
        {
            subtotal = await ApplyDiscount(cart.Coupon, subtotal);
        }

        var total = subtotal + shippingPrice;

        await CreateOrUpdateIntent(cart, total);
        await cartRepository.UpdateCartAsync(cart);

        return cart;
    }

    private async Task<long?> GetShippingPriceInCents(int? deliveryMethodId)
    {
        if (!deliveryMethodId.HasValue) return null;
        var deliveryMethod = await deliveryMethodService.GetDeliveryMethod(deliveryMethodId!.Value)
                             ?? throw new Exception("Problem with delivery method");

        return (long)(deliveryMethod.Price * 100);
    }

    private async Task UpdateCartItemsPrices(List<CartItem> items)
    {
        foreach (var item in items)
        {
            var productItem = await queryExecutor.Execute(new GetProductQuery { Id = item.ProductId })
                              ?? throw new Exception("Problem getting product in cart");

            if (item.Price != productItem.Price)
            {
                item.Price = productItem.Price;
            }
        }
    }

    private static async Task CreateOrUpdateIntent(ShoppingCart cart, long total)
    {
        var service = new PaymentIntentService();

        if (string.IsNullOrEmpty(cart.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = total,
                Currency = "usd",
                PaymentMethodTypes = ["card"]
            };

            var intent = await service.CreateAsync(options);
            cart.PaymentIntentId = intent.Id;
            cart.ClientSecret = intent.ClientSecret;
        }
        else
        {
            var options = new PaymentIntentUpdateOptions
            {
                Amount = total
            };

            await service.UpdateAsync(cart.PaymentIntentId, options);
        }
    }

    private async Task<long> ApplyDiscount(AppCoupon appCoupon, long subtotalInCents)
    {
        var couponService = new Stripe.CouponService();
        var coupon = await couponService.GetAsync(appCoupon.CouponId);
        long discountInCents = 0;

        if (coupon.AmountOff.HasValue)
        {
            discountInCents = coupon.AmountOff.Value;
        }
        else if (coupon.PercentOff.HasValue)
        {
            discountInCents = (long)(subtotalInCents * (coupon.PercentOff.Value / 100));
        }

        discountInCents = Math.Min(discountInCents, subtotalInCents);

        return subtotalInCents - discountInCents;
    }
    private static long CalculateSubtotal(ShoppingCart cart)
    {
        var itemTotal = cart.Items.Sum(x => x.Quantity * x.Price * 100);

        return (long)itemTotal;
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
        var order = await orderData.GetOrder(intent.Id)
            ?? throw new InvalidOperationException($"Order not found for PaymentIntent {intent.Id}");

        var orderTotalInCents = (long)Math.Round(order.GetTotal() * 100,
            MidpointRounding.AwayFromZero);

        var newState = intent.Status switch
        {
            "succeeded" => orderTotalInCents == intent.Amount
                ? OrderState.PaymentReceived
                : OrderState.PaymentMismatch,
            "requires_payment_method" => OrderState.PaymentFailed,
            _ => throw new InvalidOperationException($"Unsupported intent status: {intent.Status}")
        };

        var updatedOrder = new OrderEntity
        {
            Id = order.Id,
            BuyerEmail = order.BuyerEmail,
            CreatedAt = order.CreatedAt,
            ShippingAddress = order.ShippingAddress,
            DeliveryMethod = order.DeliveryMethod,
            PaymentSummary = order.PaymentSummary,
            Subtotal = order.Subtotal,
            Discount = order.Discount,
            OrderState = newState,
            Invoice = order.Invoice,
            PaymentIntentId = order.PaymentIntentId,
            OrderItems = order.OrderItems,
            Reservations = order.Reservations
        };

        var connectionId = NotificationHub.GetConnectionIdByEmail(updatedOrder.BuyerEmail);
        if (!string.IsNullOrEmpty(connectionId))
        {
            await hubContext.Clients.Client(connectionId).SendAsync("OrderCompleteNotification", updatedOrder);
        }

        return await orderData.UpdateOrder(updatedOrder);
    }
}