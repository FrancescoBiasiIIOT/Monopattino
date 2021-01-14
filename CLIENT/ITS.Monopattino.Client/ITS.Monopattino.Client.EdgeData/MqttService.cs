using ITS.Monopattino.Client.Models;
using ITS.Monopattino.Client.WorkerService;
using M2Mqtt.Messages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ITS.Monopattino.Client.EdgeData
{
    public class MqttService : IMqttService
    {
        public void ReceiveDataFromServer(object sender, MqttMsgPublishEventArgs e)
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
                case "Lights":
                    Worker.SetLights(command.Value);
                    break;
                case "Speed":
                    Worker.SetLights(command.Value);
                    break;
            }

        }


    }
}
