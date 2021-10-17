using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class GetBouquetsHandler : IRequestHandler<GetBouquetsRequest, GetBouquetsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Bouquet> bouquetRepository;
        private readonly IMapper mapper;

        public GetBouquetsHandler(IRepository<DataAccess.Entities.Bouquet> bouquetRepository,
            IMapper mapper)
        {
            this.bouquetRepository = bouquetRepository;
            this.mapper = mapper;
        }        

        public async Task<GetBouquetsResponse> Handle(GetBouquetsRequest request, CancellationToken cancellationToken)
        {
            var bouquets = await this.bouquetRepository.GetAll();
            var mappedBouquets = this.mapper.Map<List<Domain.Models.Bouquet>>(bouquets);
            var response = new GetBouquetsResponse()
            {
                Data = mappedBouquets
            };

            return response;
        }
    }
}
