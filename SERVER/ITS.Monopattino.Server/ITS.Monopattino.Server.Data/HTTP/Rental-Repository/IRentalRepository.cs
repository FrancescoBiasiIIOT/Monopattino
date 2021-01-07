using ITS.Monopattino.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Data.Rental_Repository
{
    public interface IRentalRepository
    {
        public IEnumerable<Rental> GetRentals();
        public void InsertRental(Rental rental);
    }
}
