using ITS.Monopattino.Client.Models;
using M2Mqtt;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Data.Protocol
{
    public interface IProtocol
    {
        IModel GetClient();
        IModel ConfigureClient();
        void Send(Object detection,string type,int id);
    }
}
