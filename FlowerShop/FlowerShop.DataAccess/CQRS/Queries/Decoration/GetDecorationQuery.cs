namespace FlowerShop.DataAccess.CQRS.Queries.Decoration
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Sieve.Services;
    using System.Threading.Tasks;

    public class GetDecorationQuery : QueryBase<Decoration>
    {
        public int Id { get; init; }

        public override async Task<Decoration> Execute(FlowerShopStorageContext context) 
            => await context.Decorations.FirstOrDefaultAsync(x => x.Id == this.Id);            
    }
}