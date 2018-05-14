using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class NumberOfParkingPlaceDoesNotExistException : Exception
    {
        public NumberOfParkingPlaceDoesNotExistException(string message)
            : base(message)
        {

        }
    }
}
