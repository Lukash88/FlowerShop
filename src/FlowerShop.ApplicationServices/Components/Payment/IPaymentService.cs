using FlowerShop.DataAccess.Core.Entities;
using Microsoft.Extensions.Primitives;
using Stripe;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Payment
{
    public interface IPaymentService
    {
        Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId);
        Event ConstructStripeEvent(string json, StringValues stripeSignature);
        Task<OrderEntity> HandlePaymentIntentSucceeded(PaymentIntent intent);
    }
}