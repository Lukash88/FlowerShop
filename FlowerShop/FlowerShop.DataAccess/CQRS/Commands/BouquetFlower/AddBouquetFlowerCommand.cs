namespace FlowerShop.DataAccess.CQRS.Commands.BouquetFlower
{
    using FlowerShop.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddBouquetFlowerCommand : CommandBase<List<BouquetFlower>, List<BouquetFlower>>
    {
        public override async Task<List<BouquetFlower>> Execute(FlowerShopStorageContext context)
        {
            context.BouquetFlowers.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}