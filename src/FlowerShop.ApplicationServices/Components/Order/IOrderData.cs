using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IOrderData
    {
        Task<OrderEntity> GetOrder(string paymentIntentId);
        Task<OrderEntity> CreateOrder(OrderEntity order);
        Task<OrderEntity> UpdateOrder(OrderEntity order);
    }
}