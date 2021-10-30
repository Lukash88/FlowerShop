namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailRequest, UpdateOrderDetailResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateOrderDetailHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateOrderDetailResponse> Handle(UpdateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = this.mapper.Map<DataAccess.Entities.OrderDetail>(request);
            var command = new UpdateOrderDetailCommand()
            {
                Parameter = orderDetail
            };
            var orderDetailFromDb = await this.commandExecutor.Execute(command);

            return new UpdateOrderDetailResponse()
            {
                Data = this.mapper.Map<Domain.Models.OrderDetail>(orderDetailFromDb)
            };
        }
    }
}
