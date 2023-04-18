﻿using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Order;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using FlowerShop.DataAccess.CQRS.Queries.User;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public class UpdateOrderHandler // : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        //public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        //{
        //    var query = new GetOrderQuery()
        //    {
        //        BasketId = request.OrderId
        //    };
        //    var getOrder = await this.queryExecutor.Execute(query);
        //    if (getOrder == null)
        //    {
        //        return new UpdateOrderResponse()
        //        {
        //            Error = new ErrorModel(ErrorType.NotFound)
        //        };
        //    }

        //    var ordersQuery = new GetOrdersQuery(); 
        //    var getOrders = await this.queryExecutor.ExecuteWithSieve(ordersQuery);
        //    var usersQuery = new GetUsersQuery();
        //    var getUsers = await this.queryExecutor.ExecuteWithSieve(ordersQuery);
        //    //if ((getUsers.Select(x => x.BasketId).Contains(request.UserId) &&
        //    //    getOrders.Select(x => x.UserId).Contains(request.UserId)) ||
        //    //    !getOrders.Select(x => x.BasketId).Contains(request.UserId))
        //    //{
        //    //    return new UpdateOrderResponse()
        //    //    {
        //    //        Error = new ErrorModel(ErrorType.NotFound)
        //    //    };
        //    //}

        //    var mappedOrder = this.mapper.Map<DataAccess.Core.Entities.Order>(request);
        //    var command = new UpdateOrderCommand()
        //    {
        //        Parameter = mappedOrder
        //    };
        //    var updatedOrder = await this.commandExecutor.Execute(command);
        //    var response =  new UpdateOrderResponse()
        //    {
        //        Data = this.mapper.Map<Domain.Models.OrderDTO>(updatedOrder)
        //    };

        //    return response;
        //}
    }
}