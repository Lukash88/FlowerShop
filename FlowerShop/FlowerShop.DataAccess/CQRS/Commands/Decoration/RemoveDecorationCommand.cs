namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class RemoveDecorationCommand : CommandBase<Decoration, Decoration>
    {
        public override async Task<Decoration> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Decorations.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
