using ITS.Monopattino.Server.Models.Models;
using ITS.Monopattino.Server.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ITS.Monopattino.Server.MqttServer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDetectionService detectionService;
        private readonly string _IP = "127.0.0.1";
        private readonly string subscription_endpoint = "monopattino/#";
        private readonly string endpoint = "monopattino/#";
        public Worker(ILogger<Worker> logger, IDetectionService detectionService)
        {
            _logger = logger;
            this.detectionService = detectionService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ConfigureClient();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ConfigureClient()
        {
            MqttClient client = new MqttClient(IPAddress.Parse(_IP));
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Subscribe(new string[] { subscription_endpoint }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        }
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string result = System.Text.Encoding.UTF8.GetString(e.Message);
            var topic = e.Topic.Split('/');
            var res = detectionService.GetTypeOfTopic(topic[2],result);
            var detection = new DetectionInfo(res);
            detection.ScooterId = Convert.ToInt32(topic[1]);
            detection.DateTime = DateTime.Now;
            detectionService.InsertDetection(detection);
            Console.WriteLine("topic: " + e.Topic);
        }
    }
}
