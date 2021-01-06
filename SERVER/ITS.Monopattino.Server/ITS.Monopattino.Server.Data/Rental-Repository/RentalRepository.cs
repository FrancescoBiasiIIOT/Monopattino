using ITS.Monopattino.Server.Data.Detection_Repository;
using ITS.Monopattino.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Monopattino.Server.Data.Rental_Repository
{
    public class RentalRepository : IRentalRepository
    {
        public ValleProjectContext Context { get; set; }

        public RentalRepository(ValleProjectContext context)
        {
            Context = context;
        }

        public IEnumerable<Rental> GetRentals()
        {
            return Context.Rentals.
            Include(d => d.Scooter).Include(u => u.User).
            ToList(); //ritorna tutto il contenuto della tabella
        }

        public void InsertRental(Rental rental)
        {
            Context.Rentals.Add(rental);
            Context.SaveChanges();
        }
    }
}
