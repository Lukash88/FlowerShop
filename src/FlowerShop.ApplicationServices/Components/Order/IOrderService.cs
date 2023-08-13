using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IOrderService
    {
        public Task<List<OrderItem>> GetOrderItems(string basketId);

        public Task<DataAccess.Core.Entities.OrderAggregate.Order> CreateOrder(
            DataAccess.Core.Entities.OrderAggregate.Order order,
            DeliveryMethod deliveryMethod, List<OrderItem> items, decimal subtotal, string email,
            Address shippingAddress);

        public decimal GetSubtotal(List<OrderItem> items);
        public Task<DeliveryMethod> GetDeliveryMethod(int id);
    }
}