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
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    //public class GetProductsHandler : IRequestHandler<GetProductsRequest, PagedResponse<GetProductsResponse>>
    public class GetProductsHandler : PagedRequestHandler<GetProductsRequest, PagedResponse<GetProductsResponse>>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly SieveProcessor sieveProcessor;

        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor, SieveProcessor sieveProcessor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
        }
        public override async Task<PagedResponse<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery()
            {
                SieveModel = request.SieveModel
            };

            var products = await this.queryExecutor.ExecuteWithSieve(query);
            if (products == null)
            {
                return new PagedResponse<GetProductsResponse>()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

           
            //var queryable = products.AsQueryable();
            //products.AsQueryable();
            // var mappedProducts = this.mapper.Map<List<Domain.Models.ProductDTO>>(products);
            
            var response = new PagedResponse<GetProductsResponse>()
            {
                //Results = products
                // Data = mappedProducts
                //Results = (IList<GetProductsResponse>)products  //mappedProducts   //products.ToList()
            };


            //return await response.ToPagedAsync<GetProductsRequest, GetProductsResponse>(query, mapper, sieveProcessor, request.SieveModel);

            /*response.Results = await products.ToP*/

            // return response.ToPagedAsync<GetProductsRequest, GetProductsResponse>();

            //return response;

            return await response.ToPagedAsync<GetProductsRequest, GetProductsResponse>(request, mapper, sieveProcessor, query.SieveModel);

           
            //var productsPaged = PagedResponseExtension.ToPagedAsync(query, mapper, sieveProcessor, query.SieveModel);

          
            //return productsPaged;


        }
    }
}
