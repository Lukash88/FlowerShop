using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace FlowerShop.DataAccess.CQRS.Queries.Decoration;

public class GetDecorationsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Decoration>>
{
    public required SieveModel SieveModel { get; init; }

    public override async Task<IQueryable<Core.Entities.Decoration>> Execute(FlowerShopStorageContext context,
        ISieveProcessor sieveProcessor)
    {
        var query = context.Decorations.AsNoTracking();

        return await Task.FromResult(query);
    }
}