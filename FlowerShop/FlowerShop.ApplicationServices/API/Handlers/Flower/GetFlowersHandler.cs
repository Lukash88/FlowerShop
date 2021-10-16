using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    public class GetFlowersHandler : IRequestHandler<GetFlowersRequest, GetFlowersResponse>
    {
        private readonly IRepository<DataAccess.Entities.Flower> flowerRepository;

        public GetFlowersHandler(IRepository<DataAccess.Entities.Flower> flowerRepository)
        {
            this.flowerRepository = flowerRepository;
        }

        public Task<GetFlowersResponse> Handle(GetFlowersRequest request, CancellationToken cancellationToken)
        {
            var flowers = this.flowerRepository.GetAll();
            var domainFlowers = flowers.Select(x => new Domain.Models.Flower()
            {
                Id = x.Id,
                Name = x.Name,
                FlowerType = x.FlowerType,
                Description = x.Description,
                LengthInCm = x.LengthInCm,
                Colour = x.Colour
            });

            var response = new GetFlowersResponse()
            {
                Data = domainFlowers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
