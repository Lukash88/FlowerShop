namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.Entities;
    using FlowerShop.DataAccess.CQRS.Commands.Reservation;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveReservationHandler : IRequestHandler<RemoveReservationRequest, RemoveReservationResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveReservationHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<RemoveReservationResponse> Handle(RemoveReservationRequest request, CancellationToken cancellationToken)
        {
            var reservation = mapper.Map<Reservation>(request);
            var command = new RemoveReservationCommand()
            {
                Parameter = reservation
            };
            await this.commandExecutor.Execute(command);
            var response = new RemoveReservationResponse()
            {
                Data = null
            };

            return response;
        }
    }
}