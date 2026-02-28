using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Components.Order;

public interface IOrderItemService
{
    Task<List<OrderItem>> GenerateOrderItems(string cartId);
    Task<List<OrderItem>> UpdateOrderItems(UpdateOrderRequest request);
    decimal GetSubtotal(IEnumerable<OrderItem> items);
}