using ITS.Monopattino.Server.Models.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace ITS.Monopattino.Server.Services.Mqtt_Services
{
    public class AmqpService :  IAmqpService
    {
        private readonly IDetectionService detectionService;
        private  IModel channel;

        public AmqpService(IDetectionService detectionService)
        {
            this.detectionService = detectionService;
          
        }


        public void ConfigureClient(string queue)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://jxrkaslv:Z1Fcv_pgolg4tlIBslNriiCo-OshWZs7@bonobo.rmq.cloudamqp.com/jxrkaslv") } ;
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.BasicQos(0, 1, false);
            var messageReceiver = new MessageReceiver(channel, detectionService);
            channel.BasicConsume(queue, false, messageReceiver);
        }

        public void Client_SendMessage(Command command, string typeOfCommand, int deviceId)
        {
            var message = JsonConvert.SerializeObject(command);

        }
    }
}
