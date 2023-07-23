using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    using System.Threading.Tasks;

    public class UpdateDecorationCommand : CommandBase<Core.Entities.Decoration, Core.Entities.Decoration>
    {
        public override async Task<Core.Entities.Decoration> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Decorations.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}