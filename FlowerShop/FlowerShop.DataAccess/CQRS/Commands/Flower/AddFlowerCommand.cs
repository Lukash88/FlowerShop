namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddFlowerCommand : CommandBase<Flower, Flower>
    {
        public override async Task<Flower> Execute(FlowerShopStorageContext context)
        {
            await context.Flowers.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}