using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderItemEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.OrderItem;

namespace FlowerShop.DataAccess.CQRS.Queries.OrderItem
{
    public sealed class GetOrderItemsQuery : QueryBase<List<OrderItemEntity>>
    {
        public int OrderId { get; init; }

        public override async Task<List<OrderItemEntity>> Execute(
            FlowerShopStorageContext context)
        {
            return await context.Orders
                .Where(o => o.Id == OrderId)
                .Include(o => o.OrderItems)
                .SelectMany(o => o.OrderItems).ToListAsync();
        }
    }
}