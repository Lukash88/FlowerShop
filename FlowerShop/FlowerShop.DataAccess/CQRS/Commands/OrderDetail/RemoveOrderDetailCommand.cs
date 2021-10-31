namespace FlowerShop.DataAccess.CQRS.Commands.OrderDetail
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class RemoveOrderDetailCommand : CommandBase<OrderDetail, OrderDetail>
    {
        public override async Task<OrderDetail> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.OrderDetails.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
