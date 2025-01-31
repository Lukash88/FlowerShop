using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Product;

public class UpdateProductCommand : CommandBase<Core.Entities.Product, Core.Entities.Product>
{
    public override async Task<Core.Entities.Product> Execute(FlowerShopStorageContext context)
    {
        context.ChangeTracker.Clear();
        context.Products.Update(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}