namespace FlowerShop.DataAccess.CQRS.Commands.Product
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class RemoveProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Products.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}