namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using DataAccess.Entities;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Reservation;
    using FlowerShop.DataAccess.CQRS.Queries.Order;
    using FlowerShop.DataAccess.CQRS.Queries.Reservation;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateReservationHandler : IRequestHandler<UpdateReservationRequest, UpdateReservationResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public UpdateReservationHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<UpdateReservationResponse> Handle(UpdateReservationRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReservationQuery()
            {
                Id = request.ReservationId
            };
            var getReservation = await this.queryExecutor.Execute(query);
            if (getReservation == null)
            {
                return new UpdateReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var reservationsQuery = new GetReservationsQuery();
            var getReservations = await this.queryExecutor.Execute(reservationsQuery);
            var ordersQuery = new GetOrdersQuery();
            var getOrders = await this.queryExecutor.Execute(ordersQuery);

            if (!getOrders.Select(x => x.Id).Contains(request.OrderId)) 
            {
                return new UpdateReservationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedReservation = this.mapper.Map<Reservation>(request);
            var command = new UpdateReservationCommand()
            {
                Parameter = mappedReservation
            };
            var updatedReservation = await this.commandExecutor.Execute(command);
            var response =  new UpdateReservationResponse()
            {
                Data = this.mapper.Map<Domain.Models.ReservationDTO>(updatedReservation)
            };

            return response;
        }
    }
}