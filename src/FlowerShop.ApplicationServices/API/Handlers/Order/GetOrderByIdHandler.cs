﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrderByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery()
            {
                Id = request.OrderId
            };
            var order = await this.queryExecutor.Execute(query);
            if (order == null)
            {
                return new GetOrderByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrder = this.mapper.Map<Domain.Models.OrderDto>(order);
            var response = new GetOrderByIdResponse()
            {
                Data = mappedOrder
            };

            return response;
        }
    }
}