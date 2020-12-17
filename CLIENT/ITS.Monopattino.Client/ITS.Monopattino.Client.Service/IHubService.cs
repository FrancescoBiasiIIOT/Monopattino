using ITS.Monopattino.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Service
{
    public interface IHubService
    {

        void Send(Microcontrollore sensors);
    }
}
