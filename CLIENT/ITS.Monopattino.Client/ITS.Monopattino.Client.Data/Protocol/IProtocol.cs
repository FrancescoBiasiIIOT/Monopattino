using ITS.Monopattino.Client.Models;
using M2Mqtt;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Data.Protocol
{
    public interface IProtocol
    {
        MqttClient GetClient();
        MqttClient ConfigureClient();
        void Send(Object detection,string type,int id);
    }
}
