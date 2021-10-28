namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class RemoveDecorationCommand : CommandBase<Decoration, Decoration>
    {
        public int Id { get; set; }

        public override async Task<Decoration> Execute(FlowerShopStorageContext context)
        {
            var decorationId = await context.Decorations.FirstOrDefaultAsync(x => x.Id == this.Id);
            context.Decorations.Remove(decorationId);
            await context.SaveChangesAsync();

            return decorationId;
        }
    }
}
