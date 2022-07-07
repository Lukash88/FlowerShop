﻿namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Reservation;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using FlowerShop.DataAccess.CQRS.Queries.Reservation;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using Sieve.Models;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddReservationHandler : IRequestHandler<AddReservationRequest, AddReservationResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddReservationHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddReservationResponse> Handle(AddReservationRequest request, CancellationToken cancellationToken)
        {
            var reservationsQuery = new GetReservationsQuery() { SieveModel = new SieveModel() }; //??
            var getReservations = await this.queryExecutor.ExecuteWithSieve(reservationsQuery);
            var ordersQuery = new GetOrdersQuery() { SieveModel = new SieveModel() }; //??
            var getOrders = await this.queryExecutor.ExecuteWithSieve(ordersQuery);

            if (!getOrders.Select(x => x.Id).Contains(request.OrderId))
            {
                return new AddReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var reservation = this.mapper.Map<Reservation>(request);
            var command = new AddReservationCommand() 
            { 
                Parameter = reservation 
            };
            var addedReservation = await this.commandExecutor.Execute(command);
            var response = new AddReservationResponse()
            {
                Data = this.mapper.Map<Domain.Models.ReservationDTO>(addedReservation)
            };

            return response;
        }
    }
}