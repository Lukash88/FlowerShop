using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public class GetReservationStateHandler : IRequestHandler<GetReservationStateRequest, GetReservationStateResponse>
    {
        private readonly IRepository<ReservationState> reservationStateRepository;

        public GetReservationStateHandler(IRepository<DataAccess.Entities.ReservationState> reservationStateRepository)
        {
            this.reservationStateRepository = reservationStateRepository;
        }   

        public Task<GetReservationStateResponse> Handle(GetReservationStateRequest request, CancellationToken cancellationToken)
        {
            var reservationStates = this.reservationStateRepository.GetAll();
            var domainReservationStates = reservationStates.Select(x => new Domain.Models.ReservationState()
            {
                Id = x.Id,
                ReservationStatus = x.ReservationStatus
            });

            var response = new GetReservationStateResponse()
            {
                Data = domainReservationStates.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
