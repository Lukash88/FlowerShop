using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    using System.Threading.Tasks;

    public class UpdateBouquetCommand : CommandBase<Core.Entities.Bouquet, Core.Entities.Bouquet>
    {
        public override async Task<Core.Entities.Bouquet> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Bouquets.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}