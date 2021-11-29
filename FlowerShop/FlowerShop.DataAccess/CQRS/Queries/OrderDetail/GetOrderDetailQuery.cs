namespace FlowerShop.DataAccess.CQRS.Queries.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetOrderDetailQuery : QueryBase<OrderDetail>
    {
        public int Id { get; init; }

        public override async Task<OrderDetail> Execute(FlowerShopStorageContext context) => 
            await context.OrderDetails.FirstOrDefaultAsync(x => x.Id == Id);
    }
}