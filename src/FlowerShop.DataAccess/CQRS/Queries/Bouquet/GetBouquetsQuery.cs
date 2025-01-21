using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet;

public class GetBouquetsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Bouquet>>
{
    public required SieveModel SieveModel { get; init; }

    public override async Task<IQueryable<Core.Entities.Bouquet>> Execute(FlowerShopStorageContext context,
        ISieveProcessor sieveProcessor)
    {
        var query = context.Bouquets.AsNoTracking();

        return await Task.FromResult(query);
    }
}