using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public class GetOrderDetailHandler : IRequestHandler<GetOrderDetailRequest, GetOrderDetailResponse>
    {
        private readonly IRepository<OrderDetail> orderDetailRepository;

        public GetOrderDetailHandler(IRepository<DataAccess.Entities.OrderDetail> orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public Task<GetOrderDetailResponse> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = this.orderDetailRepository.GetAll();
            var domainOrderDetails = orderDetails.Select(x => new Domain.Models.OrderDetail()
            {
                Id = x.Id,
                ProductQuantity = x.ProductQuantity,
                CreatedAt = x.CreatedAt,
                OrderState = x.OrderState
            });

            var response = new GetOrderDetailResponse()
            {
                Data = domainOrderDetails.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
