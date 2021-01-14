using ITS.Monopattino.Server.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ITS.Monopattino.Server.Services.Mqtt_Services
{
    public class MqttService : IMqttService
    {
        private readonly IDetectionService detectionService;
        private MqttClient client;
        private readonly string _IP = "127.0.0.1";
        private readonly string subscription_endpoint = "monopattino/#";
        private readonly string command_topic = "monopattino/";


        public MqttService(IDetectionService detectionService)
        {
            this.detectionService = detectionService;
            client = new MqttClient(IPAddress.Parse(_IP));
        }

        public void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("topic: " + e.Topic);
            string result = System.Text.Encoding.UTF8.GetString(e.Message);
            var topic = new Topic(e.Topic);
            var topicEntity = detectionService.GetClassByTopic(topic.TopicName, result);
            var detection = new DetectionInfo(topicEntity, topic.ScooterId);
            detectionService.InsertDetection(detection);
        }

        public void ConfigureClient()
        {
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Subscribe(new string[] { subscription_endpoint }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }



        public void Client_SendMessage(Command command, string typeOfCommand, int deviceId)
        {
            string endpoint = command_topic + "/"  + deviceId + "/" + "commands" + "/" + typeOfCommand ;
            var message = JsonConvert.SerializeObject(command);
            client.Publish(endpoint, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);

        }
    }
}
