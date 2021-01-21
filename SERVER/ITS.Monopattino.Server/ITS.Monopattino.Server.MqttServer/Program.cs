using ITS.Monopattino.Server.Data;
using ITS.Monopattino.Server.Services;
using ITS.Monopattino.Server.Services.Mqtt_Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Monopattino.Server.MqttServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IDetectionService, DetectionService>();
                    services.AddSingleton<IDetectionRepository, DetectionRepository>();
                    services.AddSingleton<IAmqpService, AmqpService>();
                });
    }
}
