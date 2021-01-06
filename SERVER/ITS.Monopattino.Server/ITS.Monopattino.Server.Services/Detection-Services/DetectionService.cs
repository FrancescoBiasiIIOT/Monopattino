using ITS.Monopattino.Server.Data;
using ITS.Monopattino.Server.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var detections = detectionRepository.GetDetections();
            return detections.Select(d => new DetectionInfo());
        }

        public IEnumerable<DetectionInfo> GetDetectionsByScooterId(int scooterId)
        {
            var detections = detectionRepository.GetDetectionsByScooter(scooterId);
            return detections.Select(d => new DetectionInfo());
        }

        public void InsertDetection(DetectionInfo detection)
        {
            detectionRepository.InsertDetection(new Models.Detection(detection));
        }
    }
}
