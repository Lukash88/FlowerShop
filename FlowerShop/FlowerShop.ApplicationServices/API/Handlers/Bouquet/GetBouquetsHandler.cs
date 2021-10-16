using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class GetBouquetsHandler : IRequestHandler<GetBouquetsRequest, GetBouquetsResponse>
    {
        //private readonly IRepository<DataAccess.Entities.Bouquet> bouquetRepository;
        public GetBouquetsHandler(IRepository<DataAccess.Entities.Bouquet> bouquetRepository)
        {
            this.bouquetRepository = bouquetRepository;
        }

        public IRepository<DataAccess.Entities.Bouquet> bouquetRepository { get; }

        public Task<GetBouquetsResponse> Handle(GetBouquetsRequest request, CancellationToken cancellationToken)
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

            var response = new GetBouquetsResponse()
            {
                Data = domainBouquets.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
