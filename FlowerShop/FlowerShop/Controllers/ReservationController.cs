using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ReservationController : ControllerBase
    {
        private readonly IRepository<Reservation> reservationRepository;
        //private readonly ILogger<ReservationController> _logger;

        public ReservationController(IRepository<Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        //public ReservationController(ILogger<ReservationController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        [Route("")]
        public IEnumerable<Reservation> GetAllReservations() => this.reservationRepository.GetAll();

    }
}
