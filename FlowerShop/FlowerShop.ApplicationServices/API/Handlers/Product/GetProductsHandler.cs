namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Product;
    using MediatR;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetProductsHandler : IRequestHandler<GetProductsRequest, PagedResponse<GetProductsResponse>>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor, ISieveProcessor sieveProcessor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
        }

        public async Task<PagedResponse<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery()
            {
                Name = request.Name
            };
            var products = await this.queryExecutor.Execute(query);
            if (products == null)
            {
                return null;
                //return new <PagedResponse<GetProductsResponse>>()                    
            //    {
            //        Error = new ErrorModel(ErrorType.NotFound)
            //    };
            }

            var sortedFilteredPaginatedProducts = this.sieveProcessor.Apply(request.SieveModel, products);

            var mappedProducts = this.mapper.Map<List<Domain.Models.ProductDTO>>(sortedFilteredPaginatedProducts);

            var response = new GetProductsResponse()
            {
                Data = mappedProducts
            };

            return response;
        }
    }
}