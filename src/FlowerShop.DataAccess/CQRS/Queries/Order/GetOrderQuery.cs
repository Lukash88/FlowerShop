using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    public class GetOrderQuery : QueryBase<Core.Entities.OrderAggregate.Order>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.OrderAggregate.Order> Execute(FlowerShopStorageContext context) 
            => await context.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DeliveryMethod)
                .Include(x => x.Reservations)
                .FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}