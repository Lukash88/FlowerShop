namespace FlowerShop.DataAccess.CQRS.Queries.OrderItem
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrderItemsQuery : QueryBase<List<OrderItem>>
    {
        public string Name { get; init; }

        public async override Task<List<OrderItem>> Execute(FlowerShopStorageContext context)
        {
            var orderItemsFilteredByName = !string.IsNullOrEmpty(Name) ?
                await context.OrderItems.Where(x => x.Name.Contains(Name)).ToListAsync() : await context.OrderItems.ToListAsync();

            return orderItemsFilteredByName;
        }
    }
}
