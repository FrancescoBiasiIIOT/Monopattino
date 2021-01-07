using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models.Models
{
    public interface ISummary
    {
        public double Speed { get; set; }

        public int BatteryLvl { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }
    }
}
