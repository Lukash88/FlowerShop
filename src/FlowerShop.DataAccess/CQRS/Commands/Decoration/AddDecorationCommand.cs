using FlowerShop.DataAccess.Data;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    public class AddDecorationCommand : CommandBase<Core.Entities.Decoration, Core.Entities.Decoration>
    {
        public override async Task<Core.Entities.Decoration> Execute(FlowerShopStorageContext context)
        {
            await context.Decorations.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}