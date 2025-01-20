using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Product;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Product;

public class UpdateProductHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
    public async Task<UpdateProductResponse> Handle(UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetProductQuery
        {
            Id = request.ProductId
        };
        var getProduct = await queryExecutor.Execute(query);
        if (getProduct is null)
        {
            return new UpdateProductResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedProduct = mapper.Map<DataAccess.Core.Entities.Product>(request);
        var command = new UpdateProductCommand
        {
            Parameter = mappedProduct
        };
        var productFromDb = await commandExecutor.Execute(command);
        var response = new UpdateProductResponse
        {
            Data = mapper.Map<Domain.Models.ProductDto>(productFromDb)
        };

        return response;
    }
}