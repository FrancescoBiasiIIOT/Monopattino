using ITS.Monopattino.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Services.Reservation_Services
{
    public interface IReservationService
    {
        public IEnumerable<Rental> GetRental();
        public void InsertRental(int scooterId, int userId);
    }
}
