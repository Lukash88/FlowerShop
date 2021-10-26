namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class UpdateFlowerCommand : CommandBase<Flower, Flower>
    {
        public int Id { get; init; }

        public override async Task<Flower> Execute(FlowerShopStorageContext context)
        {
            //var flowerId = await context.Flowers.FirstOrDefaultAsync(x => x.Id == this.Id);
            //context.Flowers.Remove(flowerId);
            //await context.SaveChangesAsync();

            context.Flowers.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

           // return flowerId;
        }
    }
}
