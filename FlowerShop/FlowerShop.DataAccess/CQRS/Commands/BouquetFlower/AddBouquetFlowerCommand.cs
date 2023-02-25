using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.BouquetFlower
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddBouquetFlowerCommand : CommandBase<List<Core.Entities.BouquetFlower>, List<Core.Entities.BouquetFlower>>
    {
        public override async Task<List<Core.Entities.BouquetFlower>> Execute(FlowerShopStorageContext context)
        {
            context.BouquetFlowers.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}