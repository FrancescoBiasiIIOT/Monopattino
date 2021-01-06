using ITS.Monopattino.Server.Data.Rental_Repository;
using ITS.Monopattino.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Services.Reservation_Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRentalRepository rentalRepository;

        public ReservationService(IRentalRepository rentalRepository)
        {
            this.rentalRepository = rentalRepository;
        }

        public IEnumerable<Rental> GetRental()
        {
            return rentalRepository.GetRentals();
        }

        public void InsertRental(int scooterId, int userId)
        {
            rentalRepository.InsertRental(new Rental
            {
                ScooterId = scooterId,
                StartRental = DateTime.Now,
                UserId = userId,
            }) ; 
        }
    }
}
