namespace FlowerShop.DataAccess.CQRS.Queries.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrderDetailsQuery : QueryBase<List<OrderDetail>>
    {
        public string Name { get; init; }

        public override async Task<List<OrderDetail>> Execute(FlowerShopStorageContext context)
        {
            var orderDetailsFilteredById = !string.IsNullOrEmpty(Name) ?
                await context.OrderDetails.Where(x => x.Name.Contains(Name)).ToListAsync() : await context.OrderDetails.ToListAsync();

            return orderDetailsFilteredById;
        }
    }
}