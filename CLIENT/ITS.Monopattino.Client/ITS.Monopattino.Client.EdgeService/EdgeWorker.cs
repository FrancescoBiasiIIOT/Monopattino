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

namespace ITS.Monopattino.Client.EdgeService
{
    public class EdgeWorker : BackgroundService
    {
        private readonly ILogger<EdgeWorker> _logger;
        private IHubService _services;
        private IProtocol _repository;


        public EdgeWorker(ILogger<EdgeWorker> logger, IHubService services, IProtocol repository)
        {
            _logger = logger;
            _services = services;
            _repository = repository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
        }

        public static void ReceiveDataFromDevice(Scooter scooter)
        {
            HubService.Manipolate(scooter);
        }
    }
}
