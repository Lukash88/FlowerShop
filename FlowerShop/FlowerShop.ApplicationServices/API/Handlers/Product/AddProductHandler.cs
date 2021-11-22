namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Product;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

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
            var product = this.mapper.Map<Product>(request);
            var command = new AddProductCommand() 
            { 
                Parameter = product 
            };
            if (command == null)
            {
                return new AddProductResponse()
                { 
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var productFromDb = await this.commandExecutor.Execute(command);
            var response =  new AddProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.ProductDTO>(productFromDb)
            };

            return response;
        }
    }
}