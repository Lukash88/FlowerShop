namespace FlowerShop.DataAccess.CQRS.Queries.Product
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetProductQuery : QueryBase<Product>
    {
        public int Id { get; init; }

        public override async Task<Product> Execute(FlowerShopStorageContext context) 
            => await context.Products.FirstOrDefaultAsync(x => x.Id == this.Id);      
    }
}