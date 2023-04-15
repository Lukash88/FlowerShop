using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.OrderDetail
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddOrderDetailCommand : CommandBase<Tuple<Core.Entities.OrderDetail, 
        List<Core.Entities.BouquetOrderDetail>, List<Core.Entities.DecorationOrderDetail>, List<Core.Entities.ProductOrderDetail>>, Core.Entities.OrderDetail>
    {
        public override async Task<Core.Entities.OrderDetail> Execute(FlowerShopStorageContext context)
        {
            await context.OrderDetails.AddAsync(this.Parameter.Item1);
            await context.BouquetOrderDetails.AddRangeAsync(this.Parameter.Item2);
            await context.DecorationOrderDetails.AddRangeAsync(this.Parameter.Item3);
            await context.ProductOrderDetails.AddRangeAsync(this.Parameter.Item4);
            await context.SaveChangesAsync();
            return this.Parameter.Item1;
        }
    }
}