using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetOrderQuery : QueryBase<Core.Entities.Order>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Order> Execute(FlowerShopStorageContext context) =>         
            await context.Orders
            .Include(x => x.OrderDetails)
            .Include(x  => x.Reservations)
            .FirstOrDefaultAsync(x => x.Id == this.Id);          
    }
}