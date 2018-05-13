using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class IdOfCarDoesNotExistException : Exception
    {
        public IdOfCarDoesNotExistException(string message)
            : base(message)
        {

        }
    }
}
