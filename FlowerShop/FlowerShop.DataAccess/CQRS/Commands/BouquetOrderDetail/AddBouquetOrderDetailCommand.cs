namespace FlowerShop.DataAccess.CQRS.Commands.BouquetOrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddBouquetOrderDetailCommand : CommandBase<List<BouquetOrderDetail>, List<BouquetOrderDetail>>
    {
        public override async Task<List<BouquetOrderDetail>> Execute(FlowerShopStorageContext context)
        {
            context.BouquetOrderDetails.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}