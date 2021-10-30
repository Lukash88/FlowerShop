namespace FlowerShop.DataAccess.CQRS.Queries.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrderDetailQuery : QueryBase<OrderDetail>
    {
        public int Id { get; init; }

        public async override Task<OrderDetail> Execute(FlowerShopStorageContext context)
        {
            var orderDetail = await context.OrderDetails.FirstOrDefaultAsync(x => x.Id == Id);
             
            return orderDetail;
        }
    }
}
