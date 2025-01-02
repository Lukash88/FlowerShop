using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    public class UpdateDecorationCommand : CommandBase<Core.Entities.Decoration, Core.Entities.Decoration>
    {
        public override async Task<Core.Entities.Decoration> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Decorations.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}