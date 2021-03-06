namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    using FlowerShop.DataAccess.Entities;
    using FlowerShop.DataAccess.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetOrdersQuery : QueryBase<List<Order>>
    {
        public OrderState OrderState { get; init; }

        public async override Task<List<Order>> Execute(FlowerShopStorageContext context)
        {
            var ordersFilteredByState = OrderState != 0 ? 
                await context.Orders.Where(x => x.OrderState == OrderState).ToListAsync() : await context.Orders.ToListAsync();

            return ordersFilteredByState;
        }
    }
}