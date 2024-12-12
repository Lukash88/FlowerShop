using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Order;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using OrderEntity = FlowerShop.DataAccess.Core.Entities.OrderAggregate.Order;

namespace FlowerShop.ApplicationServices.API.Handlers.Order
{
    public sealed class GetOrderByIdForUserHandler : IRequestHandler<GetOrderByIdForUserRequest, GetOrderByIdForUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetOrderByIdForUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetOrderByIdForUserResponse> Handle(GetOrderByIdForUserRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetOrderForUserQuery()
            {
                Email = request.BuyerEmail,
                Id = request.OrderId
            };
            var order = await _queryExecutor.Execute(query);
            if (order is null)
            {
                return new GetOrderByIdForUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOrder = _mapper.Map<OrderEntity, OrderToReturnDto>(order);
            var response = new GetOrderByIdForUserResponse()
            {
                Data = mappedOrder
            };

            return response;
        }
    }
}