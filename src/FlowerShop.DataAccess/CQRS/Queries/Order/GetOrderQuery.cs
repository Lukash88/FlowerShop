using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    public class GetOrderQuery : QueryBase<OrderEntity>
    {
        public int Id { get; init; }

        public override async Task<OrderEntity> Execute(FlowerShopStorageContext context)
            => await context.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.Reservations)
                .FirstOrDefaultAsync(x => x.Id == Id);
    }
}