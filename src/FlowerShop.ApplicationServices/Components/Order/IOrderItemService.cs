using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetOrderItems(string basketId);
        Task<List<OrderItem>> GetOrderItemsForUpdate(UpdateOrderRequest request, OrderEntity order);
        decimal GetSubtotal(IEnumerable<OrderItem> items);
    }
}