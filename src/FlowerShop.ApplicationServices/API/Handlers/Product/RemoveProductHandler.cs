using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Product;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, RemoveProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public RemoveProductHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {           
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<RemoveProductResponse> Handle(RemoveProductRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery()
            {
                Id = request.ProductId
            };
            var getProduct = await _queryExecutor.Execute(query);
            if (getProduct is null)
            {
                return new RemoveProductResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedProduct = _mapper.Map<DataAccess.Core.Entities.Product>(request);
            var command = new RemoveProductCommand()
            {
                Parameter = mappedProduct
            };
            var removedProduct = await _commandExecutor.Execute(command);
            var response = new RemoveProductResponse()
            {
                Data = _mapper.Map<Domain.Models.ProductDto>(removedProduct)
            };

            return response;
        }
    }
}