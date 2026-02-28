using FlowerShop.DataAccess.Core.Entities;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FlowerShop.DataAccess.Repositories.CartRepository;

public class CartRepository(IConnectionMultiplexer redis) : ICartRepository
{
    private readonly IDatabase _database = redis.GetDatabase();
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() },
        WriteIndented = false,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public async Task<ShoppingCart?> UpdateCartAsync(ShoppingCart? cart)
    {
        if (cart is null) return null;

        var serialized = JsonSerializer.Serialize(cart, _jsonOptions);

        var created = await _database.StringSetAsync(cart.Id, serialized);
        if (!created) return null;

        return await GetCartAsync(cart.Id);
    }

    public async Task<ShoppingCart?> GetCartAsync(string cartId)
    {
        var data = await _database.StringGetAsync(cartId);

        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(data!, _jsonOptions);
    }

    public async Task<bool> DeleteCartAsync(string cartId)
    {
        return await _database.KeyDeleteAsync(cartId);
    }
}