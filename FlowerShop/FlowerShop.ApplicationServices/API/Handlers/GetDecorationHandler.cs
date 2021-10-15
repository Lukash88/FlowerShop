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
    public class GetDecorationHandler : IRequestHandler<GetDecorationRequest, GetDecorationResponse>
    {
        private readonly IRepository<Decoration> decorationRepository;

        public GetDecorationHandler(IRepository<DataAccess.Entities.Decoration> decorationRepository)
        {
            this.decorationRepository = decorationRepository;
        }

        public Task<GetDecorationResponse> Handle(GetDecorationRequest request, CancellationToken cancellationToken)
        {   
             var decorations = this.decorationRepository.GetAll();
            var domainDecorations = decorations.Select(x => new Domain.Models.Decoration()
            { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Roles = x.Roles,
                Quantity = x.Quantity,
                IsAvailable = x.IsAvailable,
                Price = x.Price
            });

            var response = new GetDecorationResponse()
            {
                Data = domainDecorations.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
