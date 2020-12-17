using ITS.Monopattino.Server.Models;
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
        [HttpGet]
        public IEnumerable<Rental> GetReservations()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public void InsertReservation()
        {
            throw new NotImplementedException();
        }
    }
}
