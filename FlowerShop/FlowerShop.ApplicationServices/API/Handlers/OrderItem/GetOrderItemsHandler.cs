using FlowerShop.ApplicationServices.API.Domain.OrderItem;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    public class GetOrderItemsHandler : IRequestHandler<GetOrderItemsRequest, GetOrderItemsResponse>
    {
        private readonly IRepository<DataAccess.Entities.OrderItem> orderItemRepository;

        public GetOrderItemsHandler(IRepository<DataAccess.Entities.OrderItem> orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }

        public Task<GetOrderItemsResponse> Handle(GetOrderItemsRequest request, CancellationToken cancellationToken)
        {
            var orderItems =  this.orderItemRepository.GetAll();
            var domainOrderItems = orderItems.Select(x => new Domain.Models.OrderItem()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Category = x.Category,
                Price = x.Price
                });

            var response = new GetOrderItemsResponse()
            {
                Data = domainOrderItems.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
