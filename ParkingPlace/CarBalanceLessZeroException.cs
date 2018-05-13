using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class CarBalanceLessZeroException : Exception
    {
        public CarBalanceLessZeroException(string message)
            : base(message)
        {

        }
    }
}
