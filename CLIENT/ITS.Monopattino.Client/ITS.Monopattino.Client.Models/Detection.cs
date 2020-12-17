using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Models
{
    public class Detection
    {
        public int Id { get; set; }

        public double Speed { get; set; }

        public int BatteryLvl { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public bool Power { get; set; }

        public int ScooterId { get; set; }
    }
}
