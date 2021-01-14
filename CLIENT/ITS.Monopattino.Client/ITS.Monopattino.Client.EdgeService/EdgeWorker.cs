using ITS.Monopattino.Client.Data.Protocol;
using ITS.Monopattino.Client.Models;
using ITS.Monopattino.Client.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using ITS.Monopattino.Client.EdgeData;

namespace ITS.Monopattino.Client.EdgeService
{
    public class EdgeWorker : BackgroundService
    {
        private readonly ILogger<EdgeWorker> _logger;
        private IMqttService MqttService;


        public EdgeWorker(ILogger<EdgeWorker> logger, IMqttService mqttService)
        {
            _logger = logger;
            MqttService = mqttService;
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            MqttService.ConfigureClient();
        }
       


    }
}
