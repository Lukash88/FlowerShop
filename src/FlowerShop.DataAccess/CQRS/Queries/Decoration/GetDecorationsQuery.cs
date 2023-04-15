using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Decoration
{
    using Microsoft.EntityFrameworkCore;
    using Sieve.Models;
    using Sieve.Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetDecorationsQuery : QueryBaseWithSieve<IQueryable<Core.Entities.Decoration>>
    {
        public SieveModel SieveModel { get; init; }

        public override async Task<IQueryable<Core.Entities.Decoration>> Execute(FlowerShopStorageContext context, ISieveProcessor sieveProcessor)
        {
            var query = context.Decorations.AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}