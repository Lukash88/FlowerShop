using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Decoration;

public class AddDecorationCommand : CommandBase<Core.Entities.Decoration, Core.Entities.Decoration>
{
    public override async Task<Core.Entities.Decoration> Execute(FlowerShopStorageContext context)
    {
        await context.Decorations.AddAsync(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}