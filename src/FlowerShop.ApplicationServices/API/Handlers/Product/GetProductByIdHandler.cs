using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Product;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Product;

public class GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, 
        CancellationToken cancellationToken)
    {
        var query = new GetProductQuery
        {
            Id = request.ProductId
        };
        var product = await queryExecutor.Execute(query);
        if (product is null)
        {
            return new GetProductByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedProduct = mapper.Map<Domain.Models.ProductDto>(product);
        var response = new GetProductByIdResponse
        {
            Data = mappedProduct
        };

        return response;
    }
}