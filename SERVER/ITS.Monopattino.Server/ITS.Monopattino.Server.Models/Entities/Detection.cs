using System;

namespace ITS.Monopattino.Server.Models
{
    public class Detection
    {
        public int Id { get; set; }

        public double Speed { get; set; }

        public int Battery { get; set; }

        public bool IsOn { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Scooter Scooter { get; set; }

        public int ScooterId { get; set; }

    }
}
