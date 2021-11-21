namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddDecorationCommand : CommandBase<Decoration, Decoration>
    {
        public override async Task<Decoration> Execute(FlowerShopStorageContext context)
        {
            await context.Decorations.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}