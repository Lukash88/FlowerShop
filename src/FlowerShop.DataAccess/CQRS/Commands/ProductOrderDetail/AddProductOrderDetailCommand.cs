using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.ProductOrderDetail
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddProductOrderDetailCommand : CommandBase<List<Core.Entities.ProductOrderDetail>, List<Core.Entities.ProductOrderDetail>>
    {
        public override async Task<List<Core.Entities.ProductOrderDetail>> Execute(FlowerShopStorageContext context)
        {
            context.ProductOrderDetails.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}