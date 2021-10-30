namespace FlowerShop.DataAccess.CQRS.Commands.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddOrderDetailCommand : CommandBase<OrderDetail, OrderDetail>
    {
        public override async Task<OrderDetail> Execute(FlowerShopStorageContext context)
        {
            await context.OrderDetails.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
