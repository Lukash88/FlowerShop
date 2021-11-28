namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Reservation;
    using MediatR;
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
            var reservation = this.mapper.Map<DataAccess.Entities.Reservation>(request);
            var command = new UpdateReservationCommand()
            {
                Parameter = reservation
            };
            var reservationFromDb = await this.commandExecutor.Execute(command);

            return new UpdateReservationResponse()
            {
                Data = this.mapper.Map<Domain.Models.ReservationDTO>(reservationFromDb)
            };
        }
    }
}
