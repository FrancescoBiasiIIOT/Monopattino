using ITS.Monopattino.Client.Data.Protocol;
using ITS.Monopattino.Client.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Monopattino.Client.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();//pe ride
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();                 
                    services.AddSingleton<IHubService, HubService>();
                    services.AddSingleton<IProtocol, HttpRepository>();
                });
    }
}
