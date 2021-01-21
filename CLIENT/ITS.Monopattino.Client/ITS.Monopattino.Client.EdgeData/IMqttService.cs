using M2Mqtt.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.EdgeData
{
    public interface IMqttService
    {
        void ReceiveDataFromServer(object sender, MqttMsgPublishEventArgs e);
    }
}
