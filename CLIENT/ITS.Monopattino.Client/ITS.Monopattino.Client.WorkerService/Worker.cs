using ITS.Monopattino.Client.Models;
using ITS.Monopattino.Client.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.Monopattino.Client.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private IHubService _services;

        public Worker(ILogger<Worker> logger,IConfiguration configuration,IHubService service)
        {
            _logger = logger;
            _configuration = configuration;
            _services = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Scooter scooter = new Scooter();
            scooter.Id = 15987;
            Microcontrollore sensors = new Microcontrollore();
            sensors.Id = 1;
            

            var random = new Random();

            while (!stoppingToken.IsCancellationRequested)
            {
                sensors.Speed = random.Next(40);
                sensors.BatteryLvl = random.Next(100);
                sensors.Lat = random.NextDouble();
                sensors.Lon = random.NextDouble();
                scooter.Micro = sensors;
                _services.Send(scooter);
              

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
