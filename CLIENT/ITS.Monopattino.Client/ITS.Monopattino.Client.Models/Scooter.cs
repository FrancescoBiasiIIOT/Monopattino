﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Monopattino.Client.Models
{
    public class Scooter
    {
        public int Id { get; set; }

        public Microcontrollore Micro { get; set; }

        public string Marca { get; set; }

        public int MaxKm { get; set; }


        public Scooter()
        {
            Id = 15987;
        }
        
    }
}
