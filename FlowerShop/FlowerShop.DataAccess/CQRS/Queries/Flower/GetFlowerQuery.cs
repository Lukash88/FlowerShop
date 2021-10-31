namespace FlowerShop.DataAccess.CQRS.Queries.Flower
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetFlowerQuery : QueryBase<Flower>
    {
        public int Id { get; init; }

        public override async Task<Flower> Execute(FlowerShopStorageContext context) =>
            await context.Flowers.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
