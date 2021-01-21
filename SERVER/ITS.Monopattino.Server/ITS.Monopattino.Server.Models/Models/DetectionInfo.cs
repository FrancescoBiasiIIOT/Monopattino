using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models.Models
{
    public class DetectionInfo
    {
        public int Id { get; set; }

        public double? Speed { get; set; }

        public int? BatteryLvl { get; set; }

        public double? Lat { get; set; }

        public double? Lon { get; set; }

        public bool? Power { get; set; }

        public int? ScooterId { get; set; }

        public DateTime DateTime { get; set; }

        public DetectionInfo()
        {

        }

        public DetectionInfo(Detection detection)
        {
            Speed = detection.Speed;
            Power = detection.IsOn;
            Lat = detection.Latitude;
            Lon = detection.Longitude;
            ScooterId = 1;
            BatteryLvl = detection.Battery;

        }
        public DetectionInfo(ISummary summary, int scooterId)
        {
            Speed = summary?.Speed;
            Lat = summary?.Lat;
            Lon = summary?.Lon;
            BatteryLvl = summary?.BatteryLvl;
            DateTime = DateTime.Now;
            ScooterId = scooterId;

        }
    }
}
