using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public class GetBouquetHandler : IRequestHandler<GetBouquetRequest, GetBouquetResponse>
    {
        private readonly IRepository<Bouquet> bouquetRepository;
        public GetBouquetHandler(IRepository<DataAccess.Entities.Bouquet> bouquetRepository)
        {
            this.bouquetRepository = bouquetRepository;
        }

        public Task<GetBouquetResponse> Handle(GetBouquetRequest request, CancellationToken cancellationToken)
        {
            var bouquets = this.bouquetRepository.GetAll();
            var domainBouquets = bouquets.Select(x => new Domain.Models.Bouquet()
            {
                Id = x.Id,
                Occasion = x.Occasion,
                TypeOfArrangement = x.TypeOfArrangement,
                Quantity = x.Quantity,
                DecorationWay = x.DecorationWay
            });

            var response = new GetBouquetResponse()
            {
                Data = domainBouquets.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
