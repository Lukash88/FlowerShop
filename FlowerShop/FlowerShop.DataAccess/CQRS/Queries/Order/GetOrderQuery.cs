namespace FlowerShop.DataAccess.CQRS.Queries.Order
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetOrderQuery : QueryBase<Order>
    {
        public int Id { get; init; }

        public override async Task<Order> Execute(FlowerShopStorageContext context)
        {                                                                                                                              
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == this.Id);          
            
            return order;                                                                                                          
        }
    }
}