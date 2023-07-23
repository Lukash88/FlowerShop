using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.OrderDetail
{
    using System.Threading.Tasks;

    public class RemoveOrderDetailCommand : CommandBase<Core.Entities.OrderDetail, Core.Entities.OrderDetail>
    {
        public override async Task<Core.Entities.OrderDetail> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.OrderDetails.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}