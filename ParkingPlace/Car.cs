using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class Car
    {
        /// <summary>
        /// Identifier of car
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Car account balance
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Car type from enum CarTypes
        /// </summary>
        public CarTypes CarType { get; set; }
    }
}
