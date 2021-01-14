using ITS.Monopattino.Client.Data.Protocol;
using ITS.Monopattino.Client.Data.Protocol.Mqtt;
using ITS.Monopattino.Client.EdgeData;
using ITS.Monopattino.Client.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Monopattino.Client.EdgeService
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
                    
                    services.AddSingleton<IMqttService, MqttService>();
                    services.AddHostedService<EdgeWorker>();
                    


                });
    }
}
