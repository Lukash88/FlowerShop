namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateBouquetCommand : CommandBase<Bouquet, Bouquet>
    {
        public override async Task<Bouquet> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Bouquets.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}