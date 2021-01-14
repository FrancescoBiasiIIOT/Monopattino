using ITS.Monopattino.Client.Models;
using M2Mqtt;
using M2Mqtt.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ITS.Monopattino.Client.Data.Protocol.Mqtt
{
    public class MqttRepository : IProtocol
    {
        private readonly string ConnectionString;
        private readonly IConfiguration configuration;
        private MqttClient client;
        private readonly string command_topic = "monopattino/15987/commands/#";
        private string Endpoint;
        private byte Qos;
        public MqttRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = this.configuration.GetConnectionString("mqtt");
            Endpoint = "monopattino/";
            client = ConfigureClient();
        }
        public void Send(Object detection,string type,int id)
        {
            this.Endpoint = "monopattino/";
            Endpoint += id.ToString() + '/' + "detections" + "/";
            Endpoint += type;
            QosSelector(type);
            var json= JsonSerializer.Serialize(detection);       
            client.Publish(Endpoint, Encoding.UTF8.GetBytes(json), Qos, false);
            Console.WriteLine("Dato inviato");
        }

        public void QosSelector(string type)
        {
            if (type == "Speed" || type == "Position")
                Qos = MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE;
            else
                Qos = MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE;
        }

        public MqttClient ConfigureClient()
        {
            client=new MqttClient(IPAddress.Parse("127.0.0.1"));
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Subscribe(new string[] { command_topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            return client;
        }
        public MqttClient GetClient()
        {
            return client;
        }
    }
}
