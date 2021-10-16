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

        public GetProductsHandler(IRepository<DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = this.productRepository.GetAll();
            var domainProducts = products.Select(x => new Domain.Models.Product()
            {
                Id = x.Id,
                ShortDescription = x.ShortDescription
            });

            var response = new GetProductsResponse()
            {
                Data = domainProducts.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
