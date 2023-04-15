using FlowerShop.DataAccess.Data;

namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetBouquetQuery : QueryBase<Core.Entities.Bouquet>
    {
        public int Id { get; init; }

        public async override Task<Core.Entities.Bouquet> Execute(FlowerShopStorageContext context) =>
            await context.Bouquets.Include(x => x.Flowers).FirstOrDefaultAsync(x => x.Id == this.Id);        
    }
}