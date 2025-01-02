using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    public class RemoveDecorationCommand : CommandBase<Core.Entities.Decoration, Core.Entities.Decoration>
    {
        public override async Task<Core.Entities.Decoration> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Decorations.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}