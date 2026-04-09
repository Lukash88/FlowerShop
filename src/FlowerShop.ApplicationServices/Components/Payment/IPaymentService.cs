using FlowerShop.DataAccess.Core.Entities;
using Microsoft.Extensions.Primitives;
using Stripe;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Payment;

public interface IPaymentService
{
    Task<ShoppingCart?> CreateOrUpdatePaymentIntent(string cartId);
    Event ConstructStripeEvent(string json, StringValues stripeSignature);
    Task<OrderEntity?> HandleStripeEvent(Event stripeEvent);
    Task<string> RefundPayment(string paymentIntentId);
}