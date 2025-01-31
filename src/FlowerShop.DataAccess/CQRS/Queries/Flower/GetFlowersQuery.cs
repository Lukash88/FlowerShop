using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.Flower;

public class GetFlowersQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Flower>>
{
    public required SieveModel SieveModel { get; init; }

    public override async Task<IQueryable<Core.Entities.Flower>> Execute(FlowerShopStorageContext context,
        ISieveProcessor sieveProcessor)
    {
        var query = context.Flowers.AsNoTracking();

        return await Task.FromResult(query);
    }
}