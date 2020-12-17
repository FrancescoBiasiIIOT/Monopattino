using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Monopattino.Server.WebApi.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> GetReservations()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public IEnumerable<WeatherForecast> InsertReservation()
        {
            throw new NotImplementedException();
        }
    }
}
