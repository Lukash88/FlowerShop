namespace FlowerShop.DataAccess.CQRS.Queries.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetOrderDetailsQuery : QueryBase<List<OrderDetail>>
    {
        public int Id { get; set; }

        public override async Task<List<OrderDetail>> Execute(FlowerShopStorageContext context) =>
            await context.OrderDetails.ToListAsync();
    }
}
