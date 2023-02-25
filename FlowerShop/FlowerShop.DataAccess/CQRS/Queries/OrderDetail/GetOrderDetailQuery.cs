using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.OrderDetail
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetOrderDetailQuery : QueryBase<Core.Entities.OrderDetail>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.OrderDetail> Execute(FlowerShopStorageContext context) => 
            await context.OrderDetails
            .Include(x => x.Bouquets)
            .Include(x => x.Decorations)
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == Id);
    }
}