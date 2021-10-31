namespace FlowerShop.DataAccess.CQRS.Queries.OrderItem
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetOrderItemQuery : QueryBase<OrderItem>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override async Task<OrderItem> Execute(FlowerShopStorageContext context)
        {
            var orderItem = await context.OrderItems.FirstOrDefaultAsync(x => x.Id == this.Id);
            return orderItem;
        }
    }
}
