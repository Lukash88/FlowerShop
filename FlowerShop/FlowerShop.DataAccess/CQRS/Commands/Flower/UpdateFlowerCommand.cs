namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateFlowerCommand : CommandBase<Flower, Flower>
    {
        public override async Task<Flower> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Flowers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}