namespace FlowerShop.DataAccess.CQRS.Commands.ProductOrderDetail
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FlowerShop.DataAccess.Entities;

    public class AddProductOrderDetailCommand : CommandBase<List<ProductOrderDetail>, List<ProductOrderDetail>>
    {
        public override async Task<List<ProductOrderDetail>> Execute(FlowerShopStorageContext context)
        {
            context.ProductOrderDetails.AddRange(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}