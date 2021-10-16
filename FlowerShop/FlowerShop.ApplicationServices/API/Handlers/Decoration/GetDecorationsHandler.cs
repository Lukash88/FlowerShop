using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    public class GetDecorationsHandler : IRequestHandler<GetDecorationsRequest, GetDecorationsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Decoration> decorationRepository;

        public GetDecorationsHandler(IRepository<DataAccess.Entities.Decoration> decorationRepository)
        {
            this.decorationRepository = decorationRepository;
        }

        public Task<GetDecorationsResponse> Handle(GetDecorationsRequest request, CancellationToken cancellationToken)
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

            var response = new GetDecorationsResponse()
            {
                Data = domainDecorations.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
