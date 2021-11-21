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

//    public class RemoveReservationStateHandler : IRequestHandler<RemoveReservationStateRequest, RemoveReservationStateResponse>
//    {
//        private readonly IMapper mapper;
//        private readonly ICommandExecutor commandExecutor;

//        public RemoveReservationStateHandler(IMapper mapper, ICommandExecutor commandExecutor)
//        {
//            this.mapper = mapper;
//            this.commandExecutor = commandExecutor;
//        }
//        public async Task<RemoveReservationStateResponse> Handle(RemoveReservationStateRequest request, CancellationToken cancellationToken)
//        {
//            var reservationState = mapper.Map<Reservation>(request);
//            var command = new RemoveReservationStateCommand()
//            {
//                Parameter = reservationState
//            };
//            await this.commandExecutor.Execute(command);
//            var response = new RemoveReservationStateResponse()
//            {
//                Data = null
//            };

//            return response;
//        }
//    }
//}