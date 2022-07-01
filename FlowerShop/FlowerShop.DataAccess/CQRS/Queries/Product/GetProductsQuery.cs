namespace FlowerShop.DataAccess.CQRS.Queries.Product
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public string Name { get; init; }

        public async override Task<List<Product>> Execute(FlowerShopStorageContext context)
        {
            var productsFilteredByName = !string.IsNullOrEmpty(Name) ?
                await context.Products.AsNoTracking().OrderBy(p => p.Name).ToListAsync() : await context.Products.ToListAsync();

            return productsFilteredByName;
        }
    }
}

// var productsFilteredByName = !string.IsNullOrEmpty(Name) ?
//await context.Products.Where(x => x.Name.Contains(Name)).AsNoTracking().OrderBy(p => p.Name).ToListAsync() : await context.Products.ToListAsync();
