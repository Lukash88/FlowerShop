namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateFlowerCommand : CommandBase<Flower, Flower>
    {
        public int Id { get; init; }

        public override async Task<Flower> Execute(FlowerShopStorageContext context)
        {
            context.Flowers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
