namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Product;
    using FlowerShop.DataAccess.CQRS.Queries.Product;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveProductHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {           
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery()
            {
                Id = request.ProductId
            };
            var getProduct = await this.queryExecutor.Execute(query);
            if (getProduct == null)
            {
                return new RemoveProductResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedProduct = mapper.Map<Product>(request);
            var command = new RemoveProductCommand()
            {
                Parameter = mappedProduct
            };
            var removedProduct = await this.commandExecutor.Execute(command);
            var response = new RemoveProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDTO>(removedProduct)
            };

            return response;
        }
    }
}