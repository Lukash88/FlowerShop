using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.API.Domain.Payment
{
    public sealed class StripeWebhookResponse : ResponseBase<OrderEntity>
    {
    }
}