namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.ApplicationServices.API.Handlers.Product;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Reservation;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Sieve.Services;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetReservationsHandler : PagedRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ISieveProcessor sieveProcessor;
        private readonly ILogger<GetReservationsHandler> logger;

        public GetReservationsHandler(IMapper mapper, IQueryExecutor queryExecutor, 
            ISieveProcessor sieveProcessor, ILogger<GetReservationsHandler> logger)
        {                                                                         
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.sieveProcessor = sieveProcessor;
            this.logger = logger;
        }

        public override async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Getting a list of Reservations");

            var query = new GetReservationsQuery()
            {
                SieveModel = request.SieveModel
            };

            var reservations = await this.queryExecutor.ExecuteWithSieve(query);
            if (reservations == null)
            {
                return new GetReservationsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await reservations.ToPagedAsync<DataAccess.Core.Entities.Reservation, ReservationDTO>(sieveProcessor, mapper, query.SieveModel);
            var response = new GetReservationsResponse()
            {
                Data = results
            };

            return response;
        }
    }
}