using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsRequest, GetOrderDetailsResponse>
    {
        private readonly IRepository<DataAccess.Entities.OrderDetail> orderDetailRepository;

        public GetOrderDetailsHandler(IRepository<DataAccess.Entities.OrderDetail> orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public Task<GetOrderDetailsResponse> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = this.orderDetailRepository.GetAll();
            var domainOrderDetails = orderDetails.Select(x => new Domain.Models.OrderDetail()
            {
                Id = x.Id,
                ProductQuantity = x.ProductQuantity,
                CreatedAt = x.CreatedAt,
                OrderState = x.OrderState
            });

            var response = new GetOrderDetailsResponse()
            {
                Data = domainOrderDetails.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
