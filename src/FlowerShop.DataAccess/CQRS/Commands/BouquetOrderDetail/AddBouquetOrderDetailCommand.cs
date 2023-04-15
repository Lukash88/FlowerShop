using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.BouquetOrderDetail
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddBouquetOrderDetailCommand : CommandBase<List<Core.Entities.BouquetOrderDetail>, List<Core.Entities.BouquetOrderDetail>>
    {
        public override async Task<List<Core.Entities.BouquetOrderDetail>> Execute(FlowerShopStorageContext context)
        {
            context.BouquetOrderDetails.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}