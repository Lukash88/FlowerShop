using AutoMapper;
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
        private readonly IMapper mapper;

        public GetDecorationsHandler(IRepository<DataAccess.Entities.Decoration> decorationRepository,
            IMapper mapper)
        {
            this.decorationRepository = decorationRepository;
            this.mapper = mapper;
        }

        public async Task<GetDecorationsResponse> Handle(GetDecorationsRequest request, CancellationToken cancellationToken)
        {   
            var decorations = await this.decorationRepository.GetAll();
            var mappedDecorations = this.mapper.Map<List<Domain.Models.Decoration>>(decorations);
            var response = new GetDecorationsResponse()
            {
                Data = mappedDecorations
            };

            return response;
        }
    }
}
