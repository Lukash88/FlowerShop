namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddBouquetCommand : CommandBase<Tuple<Bouquet, List<BouquetFlower>>, Bouquet>
    {
        public override async Task<Bouquet> Execute(FlowerShopStorageContext context)
        {
            await context.Bouquets.AddAsync(this.Parameter.Item1);
            await context.BouquetFlowers.AddRangeAsync(this.Parameter.Item2);
            await context.SaveChangesAsync();
            return this.Parameter.Item1;
        }
    }
}