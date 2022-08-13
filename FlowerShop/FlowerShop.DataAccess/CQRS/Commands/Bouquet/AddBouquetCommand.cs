namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddBouquetCommand : CommandBase<Bouquet, Bouquet>
    {
        public override async Task<Bouquet> Execute(FlowerShopStorageContext context)
        {
            await context.Bouquets.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}