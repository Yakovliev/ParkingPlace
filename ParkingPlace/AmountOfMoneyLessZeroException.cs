﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class AmountOfMoneyLessZeroException : Exception
    {
        public AmountOfMoneyLessZeroException(string message)
            : base(message)
        {

        }
    }
}
