using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.ReservationState;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.ReservationState
{
    public class GetReservationStatesHandler : IRequestHandler<GetReservationStatesRequest, GetReservationStatesResponse>
    {
        private readonly IRepository<DataAccess.Entities.ReservationState> reservationStateRepository;
        private readonly IMapper mapper;

        public GetReservationStatesHandler(IRepository<DataAccess.Entities.ReservationState> reservationStateRepository,
            IMapper mapper)
        {
            this.reservationStateRepository = reservationStateRepository;
            this.mapper = mapper;
        }   

        public async Task<GetReservationStatesResponse> Handle(GetReservationStatesRequest request, CancellationToken cancellationToken)
        {
            var reservationStates = await this.reservationStateRepository.GetAll();
            var mappedReservationStates = this.mapper.Map<List<Domain.Models.ReservationStateDTO>>(reservationStates);
            var response = new GetReservationStatesResponse()
            {
                Data = mappedReservationStates
            };

            return response;
        }
    }
}
