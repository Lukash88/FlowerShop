using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddBouquetCommand : CommandBase<Tuple<Core.Entities.Bouquet, List<Core.Entities.BouquetFlower>>, Core.Entities.Bouquet>
    {
        public override async Task<Core.Entities.Bouquet> Execute(FlowerShopStorageContext context)
        {
            await context.Bouquets.AddAsync(this.Parameter.Item1);
            await context.BouquetFlowers.AddRangeAsync(this.Parameter.Item2);
            await context.SaveChangesAsync();
            return this.Parameter.Item1;
        }
    }
}