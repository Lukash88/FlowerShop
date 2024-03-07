using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    public class AddFlowerCommand : CommandBase<Core.Entities.Flower, Core.Entities.Flower>
    {
        public override async Task<Core.Entities.Flower> Execute(FlowerShopStorageContext context)
        {
            await context.Flowers.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}