using System.Text.Json;
using FlowerShop.DataAccess.Core.Entities;
using StackExchange.Redis;

namespace FlowerShop.DataAccess.Repositories.CartRepository;

public class CartRepository(IConnectionMultiplexer redis) : ICartRepository
{
    private readonly IDatabase _database = redis.GetDatabase();

    public async Task<bool> DeleteCartAsync(string cartId)
    {
        return await _database.KeyDeleteAsync(cartId);
    }

    public async Task<ShoppingCart?> GetCartAsync(string cartId)
    {
        var data = await _database.StringGetAsync(cartId);

        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(data!);
    }

    public async Task<ShoppingCart?> UpdateCartAsync(ShoppingCart cart)
    {
        var created = await _database.StringSetAsync(cart.Id, 
            JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));

        if (!created) return null;

        return await GetCartAsync(cart.Id);
    }
}