namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddOrderDetailHandler : IRequestHandler<AddOrderDetailRequest, AddOrderDetailResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddOrderDetailHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddOrderDetailResponse> Handle(AddOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = this.mapper.Map<OrderDetail>(request);
            var command = new AddOrderDetailCommand() { Parameter = orderDetail };
            if (command == null)
            {
                return new AddOrderDetailResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
                      
            var orderDetailFromDb = await this.commandExecutor.Execute(command);
            var response = new AddOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetailDTO>(orderDetailFromDb)
            };

            return response;
        }
    }
}
