using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.DataAccess.Repositories.CartRepository;

public interface ICartRepository
{
    Task<ShoppingCart?> GetCartAsync(string cartId);
    Task<ShoppingCart?> UpdateCartAsync(ShoppingCart cart);
    Task<bool> DeleteCartAsync(string cartId);
}