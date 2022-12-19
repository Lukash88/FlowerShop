namespace FlowerShop.DataAccess.CQRS.Queries.Bouquet
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetBouquetQuery : QueryBase<Bouquet>
    {
        public int Id { get; init; }

        public async override Task<Bouquet> Execute(FlowerShopStorageContext context) =>
            await context.Bouquets.Include(x => x.Flowers).FirstOrDefaultAsync(x => x.Id == this.Id);        
    }
}