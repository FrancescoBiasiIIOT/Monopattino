
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
        public BatteryInfo Battery { get; set; }

        public SpeedInfo Speed { get; set; }

        public PositionInfo Position { get; set; }

        private readonly IConfiguration _configuration;

        private IHubService _services;
        public Worker(ILogger<Worker> logger,IConfiguration configuration,IHubService service)
        {
            _logger = logger;
            _configuration = configuration;
            _services = service;
            Scooter = new Scooter();
            Battery = new BatteryInfo();
            Speed = new SpeedInfo();
            Position = new PositionInfo();
            Scooter.Battery = Battery;
            Scooter.Position = Position;
            Scooter.Speed = Speed;
            Scooter.type = 0;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                GenerateRandomData();
                HubService.Manipolate(Scooter);
                await Task.Delay(5000, stoppingToken);
            }
        }

        private void GenerateRandomData()
        {
            var random = new Random();
            if (Scooter.type == 0)
            {
                Scooter.Speed.speed = random.Next(40);
                Scooter.type++;
            }
            else if (Scooter.type == 1)
            {
                Scooter.Battery.batteryLvl = random.Next(100);
                Scooter.type++;
            }
            else
            {
                Scooter.Position.lat = random.NextDouble();
                Scooter.Position.lon = random.NextDouble();
                Scooter.type = 0;
            }
            
                    
        }
        public static void SetPower(bool value)
        {
            string accesa = value ? "Acceso" : "Spento"; 
            Console.WriteLine($"Il monopattino si è {accesa}");
        }
        public static void SetLights(bool value)
        {
            string accesa = value ? "Accese" : "Spente";
            Console.WriteLine($"Le luci sono {accesa}");
        }


    }
}
