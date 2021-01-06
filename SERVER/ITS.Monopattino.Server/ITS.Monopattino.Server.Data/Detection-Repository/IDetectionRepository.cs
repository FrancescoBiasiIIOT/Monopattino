using ITS.Monopattino.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Data
{
    public interface IDetectionRepository
    {
        public IEnumerable<Detection> GetDetections();
        public IEnumerable<Detection> GetDetectionsByScooter(int scooterId);
        public void InsertDetection(Detection detection);
    }
}
