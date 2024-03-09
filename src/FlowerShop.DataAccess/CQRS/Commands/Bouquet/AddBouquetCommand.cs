using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Bouquet
{
    public class AddBouquetCommand : CommandBase<Core.Entities.Bouquet, Core.Entities.Bouquet>
    {
        public override async Task<Core.Entities.Bouquet> Execute(FlowerShopStorageContext context)
        {
            await context.Bouquets.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}