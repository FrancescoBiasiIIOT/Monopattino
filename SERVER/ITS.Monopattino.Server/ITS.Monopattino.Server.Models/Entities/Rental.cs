using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models
{
    public class Rental
    {

        public int Id { get; set; }

        public Scooter Scooter { get; set; }

        public int ScooterId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime StartRental { get; set; }

        public DateTime? EndRental { get; set; }


    }
}
