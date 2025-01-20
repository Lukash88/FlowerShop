using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Product;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Product;

public class RemoveProductHandler(IMapper mapper, IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor) : IRequestHandler<RemoveProductRequest, RemoveProductResponse>
{
    public async Task<RemoveProductResponse> Handle(RemoveProductRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetProductQuery
        {
            Id = request.ProductId
        };
        var getProduct = await queryExecutor.Execute(query);
        if (getProduct is null)
        {
            return new RemoveProductResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedProduct = mapper.Map<DataAccess.Core.Entities.Product>(request);
        var command = new RemoveProductCommand
        {
            Parameter = mappedProduct
        };
        var removedProduct = await commandExecutor.Execute(command);
        var response = new RemoveProductResponse
        {
            Data = mapper.Map<Domain.Models.ProductDto>(removedProduct)
        };

        return response;
    }
}