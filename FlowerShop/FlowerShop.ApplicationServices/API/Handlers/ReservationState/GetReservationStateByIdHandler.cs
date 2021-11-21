//namespace FlowerShop.ApplicationServices.API.Handlers.ReservationState
//{
//    using AutoMapper;
//    using FlowerShop.ApplicationServices.API.Domain.ReservationState;
//    using FlowerShop.DataAccess.CQRS;
//    using FlowerShop.DataAccess.CQRS.Queries.ReservationState;
//    using MediatR;
//    using System.Threading;
//    using System.Threading.Tasks;

//    public class GetReservationStateByIdHandler : IRequestHandler<GetReservationStateByIdRequest, GetReservationStateByIdResponse>
//    {
//        private readonly IMapper mapper;
//        private readonly IQueryExecutor queryExecutor;

//        public GetReservationStateByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
//        {
//            this.mapper = mapper;
//            this.queryExecutor = queryExecutor;
//        }

//        public async Task<GetReservationStateByIdResponse> Handle(GetReservationStateByIdRequest request, CancellationToken cancellationToken)
//        {
//            var query = new GetReservationStateQuery()
//            {
//                Id = request.ReservationStateId
//            };
//            var reservationState = await this.queryExecutor.Execute(query);
//            var mappedReservationState = this.mapper.Map<Domain.Models.ReservationStateDTO>(reservationState);
//            var response = new GetReservationStateByIdResponse()
//            {
//                Data = mappedReservationState
//            };

//            return response;
//        }
//    }
//}
