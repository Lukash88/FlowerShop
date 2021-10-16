using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class AddBouquetHandler : IRequestHandler<AddBouquetRequest, AddBouquetResponse>
    {
        private readonly IRepository<DataAccess.Entities.Bouquet> bouquetRepository;

        public AddBouquetHandler(IRepository<DataAccess.Entities.Bouquet> bouquetRepository)
        {
            this.bouquetRepository = bouquetRepository;
        }

        public Task<AddBouquetResponse> Handle(AddBouquetRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
