using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.CQRS.Queries.Product
{
    public class GetProductQuery : QueryBase<Core.Entities.Product>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.Product> Execute(FlowerShopStorageContext context)
            => await context.Products.FirstOrDefaultAsync(x => x.Id == Id);
    }
}