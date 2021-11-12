namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using FlowerShop.DataAccess.CQRS.Queries.OrderDetail;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddOrderDetailHandler : IRequestHandler<AddOrderDetailRequest, AddOrderDetailResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderDetailHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOrderDetailResponse> Handle(AddOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsQuery();
            var getAllOrderDetails = await this.queryExecutor.Execute(query);
            var orderDetail = this.mapper.Map<OrderDetail>(request);
            var command = new AddOrderDetailCommand() 
            { 
                Parameter = orderDetail 
            };
            if (command == null)
            {
                return new AddOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            if (getAllOrderDetails.Select(x => x.ReservationId).Contains(command.Parameter.ReservationId))
            {
                return new AddOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.ValidationError)
                };
            }

            var addedOrderDetail= await this.commandExecutor.Execute(command);
            var response = new AddOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetailDTO>(addedOrderDetail)
            };

            return response;
        }
    }
}
