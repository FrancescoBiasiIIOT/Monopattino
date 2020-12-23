using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models.Models
{
    public class DetectionInfo
    {
        public int Id { get; set; }

        public double Speed { get; set; }

        public int BatteryLvl { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public bool Power { get; set; }

        public int ScooterId { get; set; }

        public DetectionInfo()
        {

        }

        public DetectionInfo(Detection detection)
        {
            Speed = detection.Speed;
            Power = detection.IsOn;
            Lat = detection.Latitude;
            Lon = detection.Longitude;
            ScooterId = detection.ScooterId;
            BatteryLvl = detection.Battery;

        }
    }
}
