using ITS.Monopattino.Server.Services.Mqtt_Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.Monopattino.Server.AMQPBatteryWorker
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
            _mqttService.ConfigureClient("battery");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}