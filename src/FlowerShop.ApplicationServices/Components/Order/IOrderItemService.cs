using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GenerateOrderItems(string basketId);
        Task<List<OrderItem>> UpdateOrderItems(UpdateOrderRequest request);
        Task<List<OrderItem>> GetOrderItems(int orderId);
        Task<List<OrderItem>> RemoveOrderItems(List<OrderItem> items);
        decimal GetSubtotal(IEnumerable<OrderItem> items);
    }
}