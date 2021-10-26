namespace FlowerShop.DataAccess.CQRS.Queries.Flower
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using FlowerShop.DataAccess.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetFlowersQuery : QueryBase<List<Flower>>
    {
        public string Name { get; init; }

        public async override Task<List<Flower>> Execute(FlowerShopStorageContext context)
        {
            var flowersFilteredByName = !string.IsNullOrEmpty(Name) ? await context.Flowers.Where(x => x.Name.Contains(Name)).ToListAsync() : await context.Flowers.ToListAsync();

            return flowersFilteredByName;
        }
    }
}
