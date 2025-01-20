using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Product;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Product;

public class AddProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
    : IRequestHandler<AddProductRequest, AddProductResponse>
{
    public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<DataAccess.Core.Entities.Product>(request);
        var command = new AddProductCommand
        { 
            Parameter = product 
        };
        var addedProduct = await commandExecutor.Execute(command);
        var response =  new AddProductResponse
        {
            Data = mapper.Map<Domain.Models.ProductDto>(addedProduct)
        };

        return response;
    }
}