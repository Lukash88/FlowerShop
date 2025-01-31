using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Product;

public class AddProductCommand : CommandBase<Core.Entities.Product, Core.Entities.Product>
{
    public override async Task<Core.Entities.Product> Execute(FlowerShopStorageContext context)
    {
        await context.Products.AddAsync(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}