using System.Threading.Tasks;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.DataAccess.Repositories.BasketRepository
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}