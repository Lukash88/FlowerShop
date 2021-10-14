using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public class GetOrderItemHandler : IRequestHandler<GetOrderItemRequest, GetOrderItemResponse>
    {
        private readonly IRepository<OrderItem> orderItemRepository;

        public GetOrderItemHandler(IRepository<DataAccess.Entities.OrderItem> orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }

        public Task<GetOrderItemResponse> Handle(GetOrderItemRequest request, CancellationToken cancellationToken)
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

            var response = new GetOrderItemResponse()
            {
                Data = domainOrderItems.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
