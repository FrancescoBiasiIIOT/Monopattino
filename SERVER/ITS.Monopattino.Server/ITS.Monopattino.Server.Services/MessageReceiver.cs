using ITS.Monopattino.Server.Data;
using ITS.Monopattino.Server.Models.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ITS.Monopattino.Server.Services
{
    public class MessageReceiver :  DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private readonly IDetectionService _detectionService;
        public MessageReceiver(IModel channel, IDetectionService detectionRepository)

        {

            _channel = channel;
            _detectionService = detectionRepository;
        }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)

        {
            Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body.ToArray())));
            var test = Encoding.UTF8.GetString(body.ToArray());
            Topic topic = new Topic(routingKey);
            var detection = _detectionService.GetClassByTopic(topic.TopicName, test);
            _detectionService.InsertDetection(new DetectionInfo(detection, topic.ScooterId)); 
            _channel.BasicAck(deliveryTag, false);

        }
    }
}
