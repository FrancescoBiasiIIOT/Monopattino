using ITS.Monopattino.Client.Data.Protocol;
using ITS.Monopattino.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Service
{
    public class HubService : IHubService
    {
        private IProtocol _repository;
        public HubService(IProtocol protocol)
        {
            _repository = protocol;
        }
        public void Send(Microcontrollore sensors)
        {
            _repository.Send(sensors.toJson());
        }
    }
}
