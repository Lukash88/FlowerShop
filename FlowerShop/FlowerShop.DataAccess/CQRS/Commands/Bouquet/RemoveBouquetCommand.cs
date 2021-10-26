namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RemoveBouquetCommand : CommandBase<Bouquet, Bouquet>
    {
        public int Id { get; init; }

        public override async Task<Bouquet> Execute(FlowerShopStorageContext context)
        {
            var bouquetId = await context.Bouquets.FirstOrDefaultAsync(x => x.Id == this.Id);
            context.Bouquets.Remove(bouquetId);
            await context.SaveChangesAsync();

            return bouquetId;
        }
    }
}