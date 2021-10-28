namespace FlowerShop.DataAccess.CQRS.Queries.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetDecorationsQuery : QueryBase<List<Decoration>>
    {
        public string Name { get; init; }

        public override async Task<List<Decoration>> Execute(FlowerShopStorageContext context)
        {
            var decorationsFilteredByName = !string.IsNullOrEmpty(Name) ? 
                await context.Decorations.Where(x => x.Name.Contains(Name)).ToListAsync() : await context.Decorations.ToListAsync();

            return decorationsFilteredByName;
        }
    }
}
