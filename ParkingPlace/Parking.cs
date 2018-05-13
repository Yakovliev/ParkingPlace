using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class Parking
    {
        /// <summary>
        /// List of cars
        /// </summary>
        public List<Car> ListOfCars { get; set; }

        /// <summary>
        /// List of transaction
        /// </summary>
        public List<Transaction> ListOfTransactions { get; set; }

        /// <summary>
        /// Balance of parking
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Instance of Parking class. Pattern Singleton
        /// </summary>
        private static readonly Parking parking = new Parking();

        private Parking()
        {

        }

        public static Parking GetParking()
        {
            return parking;
        }
    }
}
