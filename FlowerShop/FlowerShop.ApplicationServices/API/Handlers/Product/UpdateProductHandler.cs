namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Product;
    using FlowerShop.DataAccess.CQRS.Queries.Product;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;


    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public UpdateProductHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery()
            {
                Id = request.ProductId
            };
            var getDecoration = await this.queryExecutor.Execute(query);
            if (getDecoration == null)
            {
                return new UpdateProductResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedProduct = this.mapper.Map<DataAccess.Entities.Product>(request);
            var command = new UpdateProductCommand()
            {
                Parameter = mappedProduct
            };
            var productFromDb = await this.commandExecutor.Execute(command);
            var response = new UpdateProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDTO>(productFromDb)
            };

            return response;
        }
    }
}