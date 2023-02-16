using System.Threading.Tasks;
using FlowerShop.DataAccess.Entities;

namespace FlowerShop.DataAccess
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}