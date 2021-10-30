namespace FlowerShop.DataAccess.CQRS.Commands.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateDecorationCommand : CommandBase<Decoration, Decoration>
    {
        public int Id { get; init; }

        public override async Task<Decoration> Execute(FlowerShopStorageContext context)
        {          
            context.Decorations.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
