﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class ParkingPlaceIsFreeException : Exception
    {
        public ParkingPlaceIsFreeException(string message)
            : base(message)
        {

        }
    }
}
