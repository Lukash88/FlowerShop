using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("api/flowershop")]

    public class ReservationsController : ControllerBase
    {
        private readonly IRepository<Reservation> reservationRepository;

        public ReservationsController(IRepository<Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [HttpGet]
        [Route("api/flowershop")]        
        public IEnumerable<Reservation> GetAllReservations() => this.reservationRepository.GetAll();

        [HttpGet]
        [Route("{reservationId}")]
        public Reservation GetById(int reservationId)
        {
            return reservationRepository.GetById(reservationId);
        }

    }
}
