using FlowerShop.ApplicationServices.API.Domain.Order;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IOrderService
    {
        Task<OrderEntity> ProcessOrderRequest(AddOrderRequest request);
        Task<OrderEntity> ProcessUpdateOrderRequest(UpdateOrderRequest request);
    }
}