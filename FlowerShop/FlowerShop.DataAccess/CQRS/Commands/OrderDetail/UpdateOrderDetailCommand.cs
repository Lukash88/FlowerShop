namespace FlowerShop.DataAccess.CQRS.Commands.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;


    public class UpdateOrderDetailCommand : CommandBase<OrderDetail, OrderDetail>
    {
        public int Id { get; set; }

        public override async Task<OrderDetail> Execute(FlowerShopStorageContext context)
        {
            var orderDetailId = await context.OrderDetails.FirstOrDefaultAsync(x => x.Id == this.Id);
            context.OrderDetails.Remove(orderDetailId);
            await context.SaveChangesAsync();

            return orderDetailId;
        }
    }
}
