namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using FlowerShop.DataAccess.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetBouquetsQuery : QueryBase<List<Bouquet>>
    {
        public Occassion Occasion { get; init; }

        public async override Task<List<Bouquet>> Execute(FlowerShopStorageContext context)
        {
            var bouquetsFilteredByOccasion = Occasion != 0 ?
                await context.Bouquets.Where(x => x.Occasion == Occasion).Include(x => x.Flowers).ToListAsync() :
                await context.Bouquets.Include(x => x.Flowers).ToListAsync();

            return bouquetsFilteredByOccasion;
        }
    }
}

//var bouquetsFilteredByName = Occasion != 0 ?
//                await context.Bouquets.Where(x => x.Occasion == Occasion).Include(x => x.Flowers).Include(y => y.Flowers.Select(z => z.Name)).ToListAsync() :
//                await context.Bouquets.ToListAsync();

//Include(x => x.Bouquets.Select(y => y.Bouquets.Select(z => z.Flowers).ToListAsync() :