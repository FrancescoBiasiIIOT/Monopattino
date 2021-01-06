using ITS.Monopattino.Client.Data.Protocol;
using ITS.Monopattino.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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

            Detection d1 = service.CreateDetection(scooter);
            service.Send(d1);
       
        }

        public void Send(Detection detection)
        {
            _repository.Send(JsonSerializer.Serialize(detection));
        }

        public Detection CreateDetection(Scooter scooter)
        {
            return new Detection()
            {
                BatteryLvl = scooter.Micro.BatteryLvl,
                Speed = scooter.Micro.Speed,
                Id = scooter.Micro.Id,
                Lat = scooter.Micro.Id,
                Lon = scooter.Micro.Id,
                Power = scooter.Micro.Power,
                ScooterId = scooter.Id
            };
        }

    }
}
