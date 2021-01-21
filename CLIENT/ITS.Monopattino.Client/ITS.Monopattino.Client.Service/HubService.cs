using ITS.Monopattino.Client.Data.Protocol;
using ITS.Monopattino.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITS.Monopattino.Client.Service
{
    public class HubService : IHubService
    {
        private static IProtocol _repository;
        public HubService(IProtocol protocol)
        {
            _repository = protocol;
        }

        public static void Manipolate(Scooter scooter)
        {
            var service = new HubService(_repository);
            if ((scooter.type-1) == 0) 
                service.Send(scooter.Speed,scooter.Id,"speed");
            if((scooter.type -1)==1)
                service.Send(scooter.Battery, scooter.Id, "battery");
            if ((scooter.type + 2)==2)
                service.Send(scooter.Position, scooter.Id, "position");

        }

        private void Send(ISummary detection,int scooterId,string topic)
        {
            _repository.Send(detection,topic,scooterId);
        }

       
    }
}
