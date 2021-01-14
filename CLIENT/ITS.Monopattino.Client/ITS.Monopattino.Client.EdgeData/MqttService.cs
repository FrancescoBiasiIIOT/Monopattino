using ITS.Monopattino.Client.Models;
using ITS.Monopattino.Client.WorkerService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ITS.Monopattino.Client.EdgeData
{
    public class MqttService : IMqttService
    {
        private MqttClient client;
        private readonly string _IP = "127.0.0.1";
        private readonly string command_topic = "monopattino/15987/commands/#";
        public MqttService()
        {
            client = new MqttClient(IPAddress.Parse(_IP));
        }

        public void ConfigureClient()
        {
            client.MqttMsgPublishReceived += ReceiveDataFromServer;
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Subscribe(new string[] { command_topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            
        }
        public static void ReceiveDataFromServer(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("topic: " + e.Topic);
            string result = System.Text.Encoding.UTF8.GetString(e.Message);
            var command = JsonSerializer.Deserialize<Command>(result);
            var topic = new Topic(e.Topic);
            switch (topic.TopicName)
            {
                case "Power":
                    Worker.SetPower(command.Value);
                    break;
                case "Light":
                    Worker.SetLights(command.Value);
                    break;
            }
          
            //var topicEntity = detectionService.GetClassByTopic(topic.TopicName, result);
            //var detection = new DetectionInfo(topicEntity, topic.ScooterId);
            // detectionService.InsertDetection(detection);

        }
    }
}
