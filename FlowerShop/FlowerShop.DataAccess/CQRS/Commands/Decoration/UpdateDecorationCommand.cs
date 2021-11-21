namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateDecorationCommand : CommandBase<Decoration, Decoration>
    {
        public override async Task<Decoration> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Decorations.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}