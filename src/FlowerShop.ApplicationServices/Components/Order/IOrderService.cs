using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IOrderService
    {
        Task<OrderEntity> ProcessOrder(AddOrderRequest request, OrderEntity order);
        Task<OrderEntity> CreateOrder(OrderEntity order);
        Task<DeliveryMethod> GetDeliveryMethod(int id);
        Task<List<OrderItem>> GetOrderItems(string basketId);
        decimal GetSubtotal(IEnumerable<OrderItem> items);
        Task<OrderEntity> UpdateOrder(OrderEntity order);
        Task<OrderEntity> ProcessUpdateOrder(UpdateOrderRequest request, OrderEntity order);
    }
}