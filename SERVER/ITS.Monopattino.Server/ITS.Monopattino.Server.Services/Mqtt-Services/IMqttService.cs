using ITS.Monopattino.Server.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ITS.Monopattino.Server.Services.Mqtt_Services
{
    public interface IMqttService
    {
        public void ConfigureClient();
        public void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e);
        public void Client_SendMessage(Command command, string typeOfCommand, int deviceId);
    }
}
