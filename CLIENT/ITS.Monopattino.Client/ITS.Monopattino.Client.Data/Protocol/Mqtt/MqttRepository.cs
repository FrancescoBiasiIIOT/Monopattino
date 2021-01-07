using ITS.Monopattino.Client.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ITS.Monopattino.Client.Data.Protocol.Mqtt
{
    public class MqttRepository : IProtocol
    {
        private readonly string ConnectionString;
        private readonly IConfiguration configuration;
        private string Endpoint;
        private byte Qos;
        public MqttRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = this.configuration.GetConnectionString("mqtt");
            Endpoint = "monopattino/";
        }
        public void Send(Detection detection,string type)
        {
            this.Endpoint = "monopattino/";
            Endpoint += detection.ScooterId.ToString() + '/';
            Endpoint += type;
            QosSelector(type);
            var json= JsonSerializer.Serialize(detection);
            MqttClient client = new MqttClient(IPAddress.Parse("127.0.0.1"));
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            client.Subscribe(new string[] { "monopattino/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Publish(Endpoint, Encoding.UTF8.GetBytes(json), Qos, false);
        }

        public void Send(string value)
        {
            throw new NotImplementedException();
        }
        public void QosSelector(string type)
        {
            if (type == "Speed" || type == "Position")
                Qos = MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE;
            else
                Qos = MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE;
        }
    }
}
