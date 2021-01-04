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

        public static void Manipolate(Scooter sensors)
        {
            Detection d1 = new Detection()
            {
                BatteryLvl=sensors.Micro.BatteryLvl,
                Speed=sensors.Micro.Speed,
                Id=sensors.Micro.Id,
                Lat=sensors.Micro.Id,
                Lon=sensors.Micro.Id,
                Power=sensors.Micro.Power,
                ScooterId=sensors.Id
            };
            var service = new HubService(_repository);
            service.Send(d1);
       
        }

        public void Send(Detection detection)
        {
            _repository.Send(JsonSerializer.Serialize(detection));
        }

    }
}
