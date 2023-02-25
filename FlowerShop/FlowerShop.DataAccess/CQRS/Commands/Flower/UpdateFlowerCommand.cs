using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    using System.Threading.Tasks;

    public class UpdateFlowerCommand : CommandBase<Core.Entities.Flower, Core.Entities.Flower>
    {
        public override async Task<Core.Entities.Flower> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Flowers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}