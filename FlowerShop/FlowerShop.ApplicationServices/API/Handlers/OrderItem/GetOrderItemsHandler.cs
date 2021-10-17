using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.OrderItem;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.OrderItem
{
    public class GetOrderItemsHandler : IRequestHandler<GetOrderItemsRequest, GetOrderItemsResponse>
    {
        private readonly IRepository<DataAccess.Entities.OrderItem> orderItemRepository;
        private readonly IMapper mapper;

        public GetOrderItemsHandler(IRepository<DataAccess.Entities.OrderItem> orderItemRepository,
            IMapper mapper)
        {
            this.orderItemRepository = orderItemRepository;
            this.mapper = mapper;
        }

        public async Task<GetOrderItemsResponse> Handle(GetOrderItemsRequest request, CancellationToken cancellationToken)
        {
            var orderItems =  await this.orderItemRepository.GetAll();
            var mappedOrderItems = this.mapper.Map<List<Domain.Models.OrderItem>>(orderItems);
            var response = new GetOrderItemsResponse()
            {
                Data = mappedOrderItems
            };

            return response;
        }
    }
}
