﻿using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.API.Handlers.Order;

public class GetOrderByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
{
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, 
        CancellationToken cancellationToken)
    {
        var query = new GetOrderQuery
        {
            Id = request.OrderId
        };
        var order = await queryExecutor.Execute(query);
        if (order is null)
        {
            return new GetOrderByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedOrder = mapper.Map<OrderEntity, OrderToReturnDto>(order);
        var response = new GetOrderByIdResponse
        {
            Data = mappedOrder
        };

        return response;
    }
}