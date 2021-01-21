using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Models
{
    public class PositionInfo : ISummary
    {
        public double lat { get; set; }
        public double lon { get; set; }

    }
}
