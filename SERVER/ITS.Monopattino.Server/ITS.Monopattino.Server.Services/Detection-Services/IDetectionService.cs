using ITS.Monopattino.Server.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Services
{
    public interface IDetectionService
    {

        public IEnumerable<DetectionInfo> GetDetections(); 
        public IEnumerable<DetectionInfo> GetDetectionsByScooterId(int scooterId);
        public void InsertDetection(DetectionInfo detection);
        public ISummary GetClassByTopic(string topic, string result);

    }
}
