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

            Detection d1 = service.CreateDetection(scooter);
            service.SendSpeed(d1);
            Task.Delay(2000);
            service.SendPosition(d1);
            Task.Delay(2000);
            service.SendPosition(d1);

        }

        public void SendSpeed(Detection detection)
        {
            _repository.Send(detection,"Speed");
        }
        public void SendPosition(Detection detection)
        {
            _repository.Send(detection, "Position");
        }
        public void SendBattery(Detection detection)
        {
            _repository.Send(detection, "Battery");
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
