namespace FlowerShop.DataAccess.CQRS.Commands.Flower
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class RemoveFlowerCommand : CommandBase<Flower, Flower>
    {
        public int Id { get; init; }

        public override async Task<Flower> Execute(FlowerShopStorageContext context)
        {
            var flowerId = await context.Flowers.FirstOrDefaultAsync(x => x.Id == this.Id);
            context.Flowers.Remove(flowerId);
            await context.SaveChangesAsync();

            return flowerId;            
        }
    }
}