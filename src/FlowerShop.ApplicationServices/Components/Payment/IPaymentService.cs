using System.Threading.Tasks;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Components.Payment
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    }
}