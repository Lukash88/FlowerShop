using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.Product;

public class GetProductsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Product>>
{
    public required SieveModel SieveModel { get; init; }

    public override async Task<IQueryable<Core.Entities.Product>> Execute(FlowerShopStorageContext context,
        ISieveProcessor sieveProcessor)
    {
        var query = context.Products.AsNoTracking();

        return await Task.FromResult(query);
    }
}