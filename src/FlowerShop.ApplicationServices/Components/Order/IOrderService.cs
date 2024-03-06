using FlowerShop.ApplicationServices.API.Domain.Order;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IOrderService
    {
        Task<OrderEntity> ProcessOrder(AddOrderRequest request, OrderEntity order);
        Task<OrderEntity> ProcessUpdateOrder(UpdateOrderRequest request, OrderEntity order);
    }
}