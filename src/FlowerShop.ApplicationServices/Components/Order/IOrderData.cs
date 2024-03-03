using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    internal interface IOrderData
    {
        Task<OrderEntity> CreateOrder(OrderEntity order);
        Task<OrderEntity> UpdateOrder(OrderEntity order);
    }
}