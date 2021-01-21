using ITS.Monopattino.Server.Models.Models;
using ITS.Monopattino.Server.Services;
using ITS.Monopattino.Server.Services.Mqtt_Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ITS.Monopattino.Server.MqttServer
{
    public class Worker : BackgroundService
    {
        private readonly IAmqpService _mqttService;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IAmqpService mqttService)
        {
            _logger = logger;
            _mqttService = mqttService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _mqttService.ConfigureClient();
            var command = new Command(true);
            _mqttService.Client_SendMessage(command,"Lights", 15987);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}
