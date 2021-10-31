namespace FlowerShop.ApplicationServices.API.Handlers.Reservation
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Reservation;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Reservation;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddReservationHandler : IRequestHandler<AddReservationRequest, AddReservationResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddReservationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddReservationResponse> Handle(AddReservationRequest request, CancellationToken cancellationToken)
        {
            var reservation = this.mapper.Map<Reservation>(request);
            var command = new AddReservationCommand() { Parameter = reservation };
            var reservationFromDb = await this.commandExecutor.Execute(command);

            return new AddReservationResponse()
            {
                Data = this.mapper.Map<Domain.Models.ReservationDTO>(reservationFromDb)
            };
        }
    }
}
