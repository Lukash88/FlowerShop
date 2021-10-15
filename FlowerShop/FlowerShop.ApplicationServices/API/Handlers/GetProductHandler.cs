using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IRepository<Product> productRepository;

        public GetProductHandler(IRepository<DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var products = this.productRepository.GetAll();
            var domainProducts = products.Select(x => new Domain.Models.Product()
            {
                Id = x.Id,
                ShortDescription = x.ShortDescription
            });

            var response = new GetProductResponse()
            {
                Data = domainProducts.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
