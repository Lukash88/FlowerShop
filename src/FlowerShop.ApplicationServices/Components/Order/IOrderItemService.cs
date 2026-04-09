using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.Components.Order;

public interface IOrderItemService
{
    Task<List<OrderItem>> GenerateOrderItems(string cartId);
    Task<List<OrderItem>> UpdateOrderItems(UpdateOrderRequest request);
    Task AdjustStockForOrder(OrderEntity order, StockAdjustmentType adjustmentType);
    decimal GetSubtotal(IEnumerable<OrderItem> items);
}

public enum StockAdjustmentType
{
    Reduce,
    Restore
}