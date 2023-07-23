using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Product
{
    using System.Threading.Tasks;

    public class UpdateProductCommand : CommandBase<Core.Entities.Product, Core.Entities.Product>
    {
        public override async Task<Core.Entities.Product> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Products.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}