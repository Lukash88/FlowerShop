using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Order
{
    internal interface IDeliveryMethodService
    {
        Task<DeliveryMethod> GetDeliveryMethod(int id);
    }
}