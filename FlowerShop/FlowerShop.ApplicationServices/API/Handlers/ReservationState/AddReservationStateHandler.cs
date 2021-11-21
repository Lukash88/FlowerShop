//namespace FlowerShop.ApplicationServices.API.Handlers.ReservationState
//{
//    using AutoMapper;
//    using FlowerShop.ApplicationServices.API.Domain.ReservationState;
//    using FlowerShop.DataAccess.CQRS;
//    using FlowerShop.DataAccess.CQRS.Commands.ReservationState;
//    using FlowerShop.DataAccess.Entities;
//    using MediatR;
//    using System.Threading;
//    using System.Threading.Tasks;

//    public class AddReservationStateHandler : IRequestHandler<AddReservationStateRequest, AddReservationStateResponse>
//    {
//        private readonly ICommandExecutor commandExecutor;
//        private readonly IMapper mapper;

//        public AddReservationStateHandler(ICommandExecutor commandExecutor, IMapper mapper)
//        {
//            this.commandExecutor = commandExecutor;
//            this.mapper = mapper;
//        }

//        public async Task<AddReservationStateResponse> Handle(AddReservationStateRequest request, CancellationToken cancellationToken)
//        {
//            var reservationState = this.mapper.Map<Reservation>(request);
//            var command = new AddReservationStateCommand() { Parameter = reservationState };
//            var reservationStateFromDb = await this.commandExecutor.Execute(command);

//            return new AddReservationStateResponse()
//            {
//                Data = this.mapper.Map<Domain.Models.ReservationStateDTO>(reservationStateFromDb)
//            };
//        }
//    }
//}
