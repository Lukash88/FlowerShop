namespace FlowerShop.DataAccess.CQRS.Commands.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AddOrderDetailCommand : CommandBase<Tuple<OrderDetail, List<BouquetOrderDetail>>, OrderDetail>
    {
        public override async Task<OrderDetail> Execute(FlowerShopStorageContext context)
        {
            await context.OrderDetails.AddAsync(this.Parameter.Item1);
            await context.BouquetOrderDetails.AddRangeAsync(this.Parameter.Item2);
            await context.SaveChangesAsync();
            return this.Parameter.Item1;
        }
    }
}