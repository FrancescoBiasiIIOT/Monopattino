using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models.Models
{
    public class PositionInfo : ISummary
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Speed { get; set; }
        public int BatteryLvl { get; set; }

        public PositionInfo(DetectionInfo detection)
        {
            Lat = (double)detection.Lat;
            Lon = (double)detection.Lon;
        }
    }
}
