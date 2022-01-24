namespace FlowerShop.DataAccess.CQRS.Commands.Product
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddProductCommand : CommandBase<Product, Product>

    {
        public override async Task<Product> Execute(FlowerShopStorageContext context)
        {
            await context.Products.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}