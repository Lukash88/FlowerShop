using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    using System.Threading.Tasks;

    public class AddFlowerCommand : CommandBase<Core.Entities.Flower, Core.Entities.Flower>
    {
        public override async Task<Core.Entities.Flower> Execute(FlowerShopStorageContext context)
        {
            await context.Flowers.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}