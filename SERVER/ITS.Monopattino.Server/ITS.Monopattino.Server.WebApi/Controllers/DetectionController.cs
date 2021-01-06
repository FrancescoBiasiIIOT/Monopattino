using ITS.Monopattino.Server.Models;
using ITS.Monopattino.Server.Models.Models;
using ITS.Monopattino.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Monopattino.Server.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DetectionController : ControllerBase
    {
        private readonly IDetectionService detectionService;
        private readonly ILogger<DetectionController> _logger;

        public DetectionController(ILogger<DetectionController> logger, IDetectionService detectionService)
        {
            _logger = logger;
            this.detectionService = detectionService;
        }

        [HttpGet]
        public IEnumerable<DetectionInfo> Get()
        {
            return detectionService.GetDetections();
        }

        [HttpPost]
        public void Post([FromBody] DetectionInfo detection)
        {
            detectionService.InsertDetection(detection);
        }
    }
}
