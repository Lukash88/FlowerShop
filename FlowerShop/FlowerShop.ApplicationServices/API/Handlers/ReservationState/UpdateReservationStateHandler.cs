namespace FlowerShop.ApplicationServices.API.Handlers.ReservationState
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.ReservationState;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.ReservationState;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateReservationStateHandler : IRequestHandler<UpdateReservationStateRequest, UpdateReservationStateResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateReservationStateHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateReservationStateResponse> Handle(UpdateReservationStateRequest request, CancellationToken cancellationToken)
        {
            var reservationState = this.mapper.Map<DataAccess.Entities.ReservationState>(request);
            var command = new UpdateReservationStateCommand()
            {
                Parameter = reservationState
            };
            var reservationStateFromDb = await this.commandExecutor.Execute(command);

            return new UpdateReservationStateResponse()
            {
                Data = this.mapper.Map<Domain.Models.ReservationStateDTO>(reservationStateFromDb)
            };
        }
    }
}
