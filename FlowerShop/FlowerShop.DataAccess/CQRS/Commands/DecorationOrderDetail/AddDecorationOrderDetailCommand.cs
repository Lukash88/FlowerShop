using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.DecorationOrderDetail
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddDecorationOrderDetailCommand : CommandBase<List<Core.Entities.DecorationOrderDetail>, List<Core.Entities.DecorationOrderDetail>>
    {
        public override async Task<List<Core.Entities.DecorationOrderDetail>> Execute(FlowerShopStorageContext context)
        {
            context.DecorationOrderDetails.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}