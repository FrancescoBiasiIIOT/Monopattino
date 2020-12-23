using ITS.Monopattino.Server.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Monopattino.Server.Models
{
    [Table("detections")]
    public class Detection
    {
        [Key]
        public int Id { get; set; }

        public double Speed { get; set; }

        public int Battery { get; set; }

        public bool IsOn { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Scooter Scooter { get; set; }

        public int ScooterId { get; set; }

        public Detection()
        {

        }

        public Detection(DetectionInfo detection)
        {
            Speed = detection.Speed;
            IsOn = detection.Power;
            Latitude = detection.Lat;
            Longitude = detection.Lon;
            ScooterId = detection.ScooterId;
            Battery = detection.BatteryLvl;
         
        }

    }
}
