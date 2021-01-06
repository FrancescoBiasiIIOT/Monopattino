using ITS.Monopattino.Server.Data.Rental_Repository;
using ITS.Monopattino.Server.Models;
using ITS.Monopattino.Server.Services.Reservation_Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Monopattino.Server.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet]
        public IEnumerable<Rental> GetReservations()
        {
            return reservationService.GetRental();
        }


        [HttpPost("{userId}/{scooterId}", Name = "InsertReservation")]
        public void InsertReservation(int userId, int scooterId)
        {
            reservationService.InsertRental(scooterId,userId);
        }
    }
}
