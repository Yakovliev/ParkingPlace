using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class NoFreeParkingPlacesException : Exception
    {
        public NoFreeParkingPlacesException(string message)
            : base(message)
        {

        }
    }
}
