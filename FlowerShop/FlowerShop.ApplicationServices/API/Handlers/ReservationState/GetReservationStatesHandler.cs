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

        public GetReservationStatesHandler(IRepository<DataAccess.Entities.ReservationState> reservationStateRepository)
        {
            this.reservationStateRepository = reservationStateRepository;
        }   

        public Task<GetReservationStatesResponse> Handle(GetReservationStatesRequest request, CancellationToken cancellationToken)
        {
            var reservationStates = this.reservationStateRepository.GetAll();
            var domainReservationStates = reservationStates.Select(x => new Domain.Models.ReservationState()
            {
                Id = x.Id,
                ReservationStatus = x.ReservationStatus
            });

            var response = new GetReservationStatesResponse()
            {
                Data = domainReservationStates.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
