namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
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
            var orderDetailFromDb = await this.commandExecutor.Execute(command);

            return new AddOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetail>(orderDetailFromDb)
            };
        }
    }
}
