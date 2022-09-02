namespace FlowerShop.DataAccess.CQRS.Commands.DecorationOrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddDecorationOrderDetailCommand : CommandBase<List<DecorationOrderDetail>, List<DecorationOrderDetail>>
    {
        public override async Task<List<DecorationOrderDetail>> Execute(FlowerShopStorageContext context)
        {
            context.DecorationOrderDetails.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}