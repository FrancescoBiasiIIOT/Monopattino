using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Models
{
    public class Detection
    {

        public SpeedInfo Speed { get; set; }

        public BatteryInfo BatteryLvl { get; set; }

        public PositionInfo Position { get; set; }
    }
}
