namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Product;
    using Sieve.Services;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    //public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    public class GetProductsHandler : PagedRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly SieveProcessor sieveProcessor;

        //public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor, SieveProcessor sieveProcessor)
        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor, SieveProcessor sieveProcessor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
        }
        public override async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        //public override async Task<PagedResponse<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery()
            {
                SieveModel = request.SieveModel
            };

            var products = await this.queryExecutor.ExecuteWithSieve(query);
            if (products is null)
            {
                return new GetProductsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedProducts = this.mapper.Map<IQueryable<ProductDTO>>(products);

            var results = await mappedProducts.ToPagedAsync<GetProductsResponse, ProductDTO>(mapper, sieveProcessor);
            //var results  = await mappedProducts.ToPagedAsync<ProductDTO, GetProductsResponse>(mapper, sieveProcessor);

            var response = new GetProductsResponse() { Data = results };

            return response;
        }
    }
}