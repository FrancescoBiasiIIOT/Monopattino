using ITS.Monopattino.Client.EdgeService;
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
        public Scooter Scooter { get; set; }
        public Microcontrollore Microcontrollore { get; set; }
        private readonly IConfiguration _configuration;
        private IHubService _services;
        public Worker(ILogger<Worker> logger,IConfiguration configuration,IHubService service)
        {
            _logger = logger;
            _configuration = configuration;
            _services = service;
            Scooter = new Scooter();
            Microcontrollore = new Microcontrollore();
            Scooter.Micro = Microcontrollore;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                GenerateRandomData();
                EdgeWorker.ReceiveDataFromDevice(Scooter);
                await Task.Delay(5000, stoppingToken);
            }
        }

        private void GenerateRandomData()
        {
            var random = new Random();
            Scooter.Micro.Speed = random.Next(40);
            Scooter.Micro.BatteryLvl = random.Next(100);
            Scooter.Micro.Lat = random.NextDouble();
            Scooter.Micro.Lon = random.NextDouble();
        }
    }
}
