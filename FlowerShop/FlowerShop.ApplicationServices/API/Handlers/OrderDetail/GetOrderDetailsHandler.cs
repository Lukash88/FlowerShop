using AutoMapper;
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
        private readonly IMapper mapper;

        public GetOrderDetailsHandler(IRepository<DataAccess.Entities.OrderDetail> orderDetailRepository,
            IMapper mapper)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }

        public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = await this.orderDetailRepository.GetAll();
            var mappedOrderDetails = this.mapper.Map<List<Domain.Models.OrderDetail>>(orderDetails);
            var response = new GetOrderDetailsResponse()
            {
                Data = mappedOrderDetails
            };

            return response;
        }
    }
}
