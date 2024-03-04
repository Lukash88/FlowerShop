using FlowerShop.DataAccess.Core.Entities.OrderAggregate;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Order
{
    public sealed class DeliveryMethodService : IDeliveryMethodService
    {
        private readonly IQueryExecutor _queryExecutor;

        public DeliveryMethodService(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<DeliveryMethod> GetDeliveryMethod(int id)
        {
            return await _queryExecutor.Execute(new GetDeliveryMethodQuery { Id = id });
        }
    }
}