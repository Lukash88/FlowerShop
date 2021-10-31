namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Product;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;


    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateProductHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<DataAccess.Entities.Product>(request);
            var command = new UpdateProductCommand()
            {
                Parameter = product
            };
            var productFromDb = await this.commandExecutor.Execute(command);

            return new UpdateProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDTO>(productFromDb)
            };
        }
    }
}
