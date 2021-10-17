using AutoMapper;
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
        private readonly IMapper mapper;

        public GetFlowersHandler(IRepository<DataAccess.Entities.Flower> flowerRepository,
            IMapper mapper)
        {
            this.flowerRepository = flowerRepository;
            this.mapper = mapper;
        }

        public async Task<GetFlowersResponse> Handle(GetFlowersRequest request, CancellationToken cancellationToken)
        {
            var flowers = await this.flowerRepository.GetAll();
            var mappedFlowers = this.mapper.Map<List<Domain.Models.Flower>>(flowers);
            var response = new GetFlowersResponse()
            {
                Data = mappedFlowers
            };

            return response;
        }
    }
}
