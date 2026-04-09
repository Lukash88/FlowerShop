using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Product;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Product;

public sealed class UpdateProductStockHandler(IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    : IRequestHandler<UpdateProductStockRequest, UpdateProductStockResponse>
{
    public async Task<UpdateProductStockResponse> Handle(
        UpdateProductStockRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetProductQuery
        {
            Id = request.ProductId
        };

        var product = await queryExecutor.Execute(query);

        if (product is null)
        {
            return new UpdateProductStockResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        if (request.NewQuantity < 0)
        {
            return new UpdateProductStockResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest)
            };
        }

        product.StockLevel = request.NewQuantity;

        var command = new UpdateProductCommand
        {
            Parameter = product
        };

        await commandExecutor.Execute(command);

        return new UpdateProductStockResponse
        {
            Data = product.StockLevel
        };
    }
}
