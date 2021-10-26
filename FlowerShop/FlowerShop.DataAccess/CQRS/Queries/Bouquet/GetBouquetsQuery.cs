namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using FlowerShop.DataAccess.Entities;

    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using FlowerShop.DataAccess.Enums;

    public class GetBouquetsQuery : QueryBase<List<Bouquet>>
    {
        public Occassion Occasion { get; init; }

        public async override Task<List<Bouquet>> Execute(FlowerShopStorageContext context)
        {
            var bouquetsFilteredByName = Occasion !=0 ? await context.Bouquets.Where(x => x.Occasion == Occasion).ToListAsync() : await context.Bouquets.ToListAsync();

            return bouquetsFilteredByName;
        }
    }
}