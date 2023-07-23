using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Product;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {            
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<DataAccess.Core.Entities.Product>(request);
            var command = new AddProductCommand() 
            { 
                Parameter = product 
            };
            var addedProduct = await this.commandExecutor.Execute(command);
            var response =  new AddProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDto>(addedProduct)
            };

            return response;
        }
    }
}