using ITS.Monopattino.Client.Models;
using M2Mqtt;
using M2Mqtt.Messages;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ITS.Monopattino.Client.Data.Protocol.Mqtt
{
    public class AmqpRepository : IProtocol
    {
        private readonly string ConnectionString;
        private readonly IConfiguration configuration;
        IModel channel;
        public AmqpRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            channel = ConfigureClient();
        }
        public void Send(Object detection,string type,int id)
        {
            var json= JsonSerializer.Serialize(detection);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "monopattinoExchange",
                                 routingKey: "monopattino.detections." + id.ToString() + "." + type,
                                 basicProperties: null,
                                 body: body              
                                 );
            Console.WriteLine("Dato inviato");
        }



        public IModel ConfigureClient()
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://jxrkaslv:Z1Fcv_pgolg4tlIBslNriiCo-OshWZs7@bonobo.rmq.cloudamqp.com/jxrkaslv") };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
 
            return channel;
        }
        public IModel GetClient()
        {
            return channel;
        }
    }
}
