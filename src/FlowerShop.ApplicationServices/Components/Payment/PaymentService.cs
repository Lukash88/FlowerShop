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

public sealed class PaymentService : IPaymentService
{
    private readonly ICartRepository _cartRepository;
    private readonly IQueryExecutor _queryExecutor;
    private readonly IDeliveryMethodService _deliveryMethodService;
    private readonly IOrderData _orderData;
    private readonly IOrderItemService _orderItemService;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly ILogger<PaymentService> _logger;
    private readonly string? _whSecret;

    public PaymentService(IConfiguration config,
        ICartRepository cartRepository,
        IQueryExecutor queryExecutor,
        IDeliveryMethodService deliveryMethodService,
        IOrderData orderData,
        IOrderItemService orderItemService,
        IHubContext<NotificationHub> hubContext,
        ILogger<PaymentService> logger)
    {
        _cartRepository = cartRepository;
        _queryExecutor = queryExecutor;
        _deliveryMethodService = deliveryMethodService;
        _orderData = orderData;
        _orderItemService = orderItemService;
        _hubContext = hubContext;
        _logger = logger;
        _whSecret = config["StripeSettings:WebhookSecret"];
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];
    }

    public async Task<ShoppingCart?> CreateOrUpdatePaymentIntent(string cartId)
    {
        var cart = await _cartRepository.GetCartAsync(cartId) ?? throw new Exception("Cart unavailable");
        var shippingPrice = await GetShippingPriceInCents(cart.DeliveryMethodId) ?? 0;

        await UpdateCartItemsPrices(cart.Items);

        var subtotal = CalculateSubtotal(cart);

        if (cart.Coupon != null)
        {
            subtotal = await ApplyDiscount(cart.Coupon, subtotal);
        }

        var total = subtotal + shippingPrice;

        await CreateOrUpdateIntent(cart, total);
        await _cartRepository.UpdateCartAsync(cart);

        return cart;
    }

    public Event ConstructStripeEvent(string json, StringValues stripeSignature)
    {
        try
        {
            return EventUtility.ConstructEvent(json, stripeSignature, _whSecret);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to construct Stripe Event");
            throw new StripeException("Invalid signature");
        }
    }

    public async Task<OrderEntity?> HandleStripeEvent(Event stripeEvent)
    {
        _logger.LogInformation("Handling Stripe event type: {EventType}", stripeEvent.Type);

        if (stripeEvent.Data.Object is not PaymentIntent intent)
        {
            _logger.LogError("Invalid payment data in Stripe event. Object type: {Type}",
                stripeEvent.Data.Object?.GetType().Name ?? "null");
            throw new InvalidOperationException("Invalid payment data in Stripe event");
        }

        _logger.LogInformation("PaymentIntent ID: {PaymentIntentId}, Status: {Status}",
            intent.Id, intent.Status);

        OrderEntity? order = null;

        switch (stripeEvent.Type)
        {
            case "payment_intent.succeeded":
                _logger.LogInformation("Handling payment_intent.succeeded event");
                order = await HandlePaymentIntentSucceeded(intent);
                break;

            case "payment_intent.payment_failed":
                _logger.LogInformation("Handling payment_intent.payment_failed event");
                order = await HandlePaymentIntentFailed(intent);
                break;

            case "payment_intent.requires_action":
                _logger.LogInformation("Payment requires additional action");
                break;

            default:
                _logger.LogInformation("Unhandled event type: {EventType}", stripeEvent.Type);
                break;
        }

        if (order is not null)
        {
            _logger.LogInformation("Order {OrderId} processed with state: {State}", order.Id, order.OrderState);
        }

        return order;
    }

    private async Task<OrderEntity?> HandlePaymentIntentSucceeded(PaymentIntent intent)
    {
        _logger.LogInformation("HandlePaymentIntentSucceeded: {PaymentIntentId}", intent.Id);

        var order = await _orderData.GetOrder(intent.Id);

        if (order is null)
        {
            _logger.LogWarning("Order not found for PaymentIntentId: {PaymentIntentId}. " +
                "This may happen if the order hasn't been created yet.", intent.Id);
            return null;
        }

        _logger.LogInformation("Order found: {OrderId}, current state: {State}", order.Id, order.OrderState);

        if (order.OrderState == OrderState.Pending)
        {
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
                OrderState = OrderState.PaymentReceived,
                Invoice = order.Invoice,
                PaymentIntentId = order.PaymentIntentId,
                OrderItems = order.OrderItems,
                Reservations = order.Reservations
            };

            var result = await _orderData.UpdateOrder(updatedOrder);
            _logger.LogInformation("Order {OrderId} status updated to PaymentReceived", result.Id);

            var connectionId = NotificationHub.GetConnectionIdByEmail(updatedOrder.BuyerEmail);
            if (!string.IsNullOrEmpty(connectionId))
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("OrderCompleteNotification", result);
            }

            return result;
        }

        _logger.LogInformation("Order {OrderId} already in state {State}, skipping update", order.Id, order.OrderState);
        return order;
    }

    private async Task<OrderEntity?> HandlePaymentIntentFailed(PaymentIntent intent)
    {
        _logger.LogInformation("=== HandlePaymentIntentFailed: {PaymentIntentId} ===", intent.Id);

        var order = await _orderData.GetOrder(intent.Id);

        if (order is null)
        {
            _logger.LogWarning("Order not found for PaymentIntentId: {PaymentIntentId}", intent.Id);
            return null;
        }

        _logger.LogInformation("Order found: {OrderId}, current state: {State}", order.Id, order.OrderState);

        if (order.OrderState == OrderState.Pending)
        {
            await _orderItemService.AdjustStockForOrder(order, StockAdjustmentType.Restore);

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
                OrderState = OrderState.PaymentFailed,
                Invoice = order.Invoice,
                PaymentIntentId = order.PaymentIntentId,
                OrderItems = order.OrderItems,
                Reservations = order.Reservations
            };

            var result = await _orderData.UpdateOrder(updatedOrder);
            _logger.LogInformation("Order {OrderId} status updated to PaymentFailed", result.Id);

            return result;
        }

        _logger.LogInformation("Order {OrderId} already in state {State}, skipping update", order.Id, order.OrderState);
        return order;
    }

    public async Task<string> RefundPayment(string paymentIntentId)
    {
        var refundOptions = new RefundCreateOptions()
        {
            PaymentIntent = paymentIntentId
        };

        var refundService = new RefundService();
        var result = await refundService.CreateAsync(refundOptions);

        return result.Status;
    }

    private async Task<long?> GetShippingPriceInCents(int? deliveryMethodId)
    {
        if (!deliveryMethodId.HasValue) return null;
        var deliveryMethod = await _deliveryMethodService.GetDeliveryMethod(deliveryMethodId!.Value)
                             ?? throw new Exception("Problem with delivery method");

        return (long)(deliveryMethod.Price * 100);
    }

    private async Task UpdateCartItemsPrices(List<CartItem> items)
    {
        foreach (var item in items)
        {
            var productItem = await _queryExecutor.Execute(new GetProductQuery { Id = item.ProductId })
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

    private static async Task<long> ApplyDiscount(AppCoupon appCoupon, long subtotalInCents)
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
}