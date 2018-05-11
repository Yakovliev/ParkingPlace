using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class Transaction
    {
        /// <summary>
        /// Date and time of transaction
        /// </summary>
        public DateTime DateTimeOfTransaction { get; set; }

        /// <summary>
        /// Id of car
        /// </summary>
        public int IdOfCar { get; set; }

        /// <summary>
        /// Written-off funds. 
        /// If WrittenOffFunds less zero, than funds are written-off
        /// If WrittenOffFunds more zero, than funds are added
        /// </summary>
        public double WrittenOffFunds { get; set; }

    }
}
