using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models.Models
{
    public class SpeedInfo : ISummary
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Speed { get; set; }
        public int BatteryLvl { get; set; }
        public SpeedInfo(DetectionInfo detection)
        {
            Speed = detection.Speed;
        }
    }
}
