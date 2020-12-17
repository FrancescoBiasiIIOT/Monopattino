using ITS.Monopattino.Server.Models;
using System;
using System.Collections.Generic;

namespace ITS.Monopattino.Server.Data
{
    public class DetectionRepository : IDetectionRepository
    {
        //ACCESSO AI DATI
        public IEnumerable<Detection> GetDetections()
        {
            throw new NotImplementedException();
        }

        public void InsertDetection(Detection detection)
        {
            throw new NotImplementedException();
        }
    }
}
