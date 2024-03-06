using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Product
{
    public class AddProductCommand : CommandBase<Core.Entities.Product, Core.Entities.Product>
    {
        public override async Task<Core.Entities.Product> Execute(FlowerShopStorageContext context)
        {
            await context.Products.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}