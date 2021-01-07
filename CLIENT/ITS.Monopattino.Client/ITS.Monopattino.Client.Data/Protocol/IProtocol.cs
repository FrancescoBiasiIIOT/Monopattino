using ITS.Monopattino.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Data.Protocol
{
    public interface IProtocol
    {        
         void Send(Detection detection,string type);
         void Send(string value);


    }
}
