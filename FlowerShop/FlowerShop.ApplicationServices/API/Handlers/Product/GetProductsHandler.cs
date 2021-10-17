using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Product
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;
        private readonly IMapper mapper;

        public GetProductsHandler(IRepository<DataAccess.Entities.Product> productRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await this.productRepository.GetAll();
            var mappedProducts = this.mapper.Map<List<Domain.Models.Product>>(products);
            var response = new GetProductsResponse()
            {
                Data = mappedProducts
            };

            return response;
        }
    }
}
