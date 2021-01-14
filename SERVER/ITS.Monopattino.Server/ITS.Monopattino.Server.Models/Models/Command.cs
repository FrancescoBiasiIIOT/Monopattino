using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Server.Models.Models
{
    public class Command
    {
        public bool Value { get; set; }

        public Command(bool value)
        {
            Value = value;
        }
    }
}
