namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class RemoveBouquetCommand : CommandBase<Bouquet, Bouquet>
    {
        public override async Task<Bouquet> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Bouquets.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}