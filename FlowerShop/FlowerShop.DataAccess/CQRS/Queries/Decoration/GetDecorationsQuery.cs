namespace FlowerShop.DataAccess.CQRS.Queries.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetDecorationsQuery : QueryBaseWithSieve<List<Decoration>>
    {
        public SieveModel SieveModel { get; init; }

        public override async Task<List<Decoration>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = sieveProcessor.Apply(SieveModel, context.Decorations.AsNoTracking());

            return await query.ToListAsync();
        }
    }
}