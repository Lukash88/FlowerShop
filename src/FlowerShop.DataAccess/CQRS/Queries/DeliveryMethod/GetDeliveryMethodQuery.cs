using FlowerShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod
{
    public class GetDeliveryMethodQuery : QueryBase<Core.Entities.OrderAggregate.DeliveryMethod>
    {
        public int Id { get; init; }

        public override async Task<Core.Entities.OrderAggregate.DeliveryMethod> Execute(
            FlowerShopStorageContext context)
            => await context.DeliveryMethods.FirstOrDefaultAsync(x => x.Id == Id);
    }
}