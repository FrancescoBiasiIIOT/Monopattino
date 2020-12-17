using ITS.Monopattino.Server.Data;
using ITS.Monopattino.Server.Models.Models;
using System;
using System.Collections.Generic;

namespace ITS.Monopattino.Server.Services
{
    public class DetectionService : IDetectionService
    {
        //LOGICA 
        private readonly IDetectionRepository detectionRepository;

        public DetectionService(IDetectionRepository detectionRepository)
        {
            this.detectionRepository = detectionRepository;
        }

        public IEnumerable<DetectionInfo> GetDetections()
        {
            throw new NotImplementedException();
        }

        public void InsertDetection(DetectionInfo detection)
        {
            throw new NotImplementedException();
        }
    }
}
