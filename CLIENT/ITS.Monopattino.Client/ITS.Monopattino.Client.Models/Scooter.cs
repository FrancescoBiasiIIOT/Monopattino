using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Models
{
    public class Scooter
    {
        public int Id { get; set; }

        public BatteryInfo Battery{ get; set; }
        public PositionInfo Position { get; set; }
        public SpeedInfo Speed { get; set; }


        public string Marca { get; set; }

        public int MaxKm { get; set; }

        public int type { get; set; }
        public bool Power { get; set; }

        public bool Luci { get; set; }


        public Scooter()
        {
            Id = 15987;
        }
        
    }
}
