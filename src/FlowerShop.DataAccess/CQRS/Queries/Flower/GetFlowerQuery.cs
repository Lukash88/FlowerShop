using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Flower
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetFlowerQuery : QueryBase<Core.Entities.Flower>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Flower> Execute(FlowerShopStorageContext context) =>
            await context.Flowers.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}