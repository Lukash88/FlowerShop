using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Reservation;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Reservation;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    public class GetReservationsHandler : PagedRequestHandler<GetReservationsRequest, GetReservationsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly ILogger<GetReservationsHandler> _logger;

        public GetReservationsHandler(IMapper mapper, IQueryExecutor queryExecutor, 
            ISieveProcessor sieveProcessor, ILogger<GetReservationsHandler> logger)
        {                                                                         
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _sieveProcessor = sieveProcessor;
            _logger = logger;
        }

        public override async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting a list of Reservations");

            var query = new GetReservationsQuery()
            {
                SieveModel = request.SieveModel
            };

            var reservations = await _queryExecutor.ExecuteWithSieve(query);
            if (reservations is null)
            {
                return new GetReservationsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var results = await reservations.ToPagedAsync<DataAccess.Core.Entities.Reservation, ReservationDto>(_sieveProcessor, 
                _mapper, query.SieveModel, cancellationToken: cancellationToken);
            var response = new GetReservationsResponse()
            {
                Data = results
            };

            return response;
        }
    }
}