using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public interface IDeliveryMethodService
    {
        Task<DeliveryMethod> GetDeliveryMethod(int id);
    }
}