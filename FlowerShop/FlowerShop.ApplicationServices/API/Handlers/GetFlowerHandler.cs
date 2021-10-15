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
    public class GetFlowerHandler : IRequestHandler<GetFlowerRequest, GetFlowerResponse>
    {
        private readonly IRepository<Flower> flowerRepository;

        public GetFlowerHandler(IRepository<DataAccess.Entities.Flower> flowerRepository)
        {
            this.flowerRepository = flowerRepository;
        }

        public Task<GetFlowerResponse> Handle(GetFlowerRequest request, CancellationToken cancellationToken)
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

            var response = new GetFlowerResponse()
            {
                Data = domainFlowers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
