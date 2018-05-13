using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class Car : IDisposable
    {
        /// <summary>
        /// Identifier of car
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Car account balance
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Car type from enum CarTypes
        /// </summary>
        public CarTypes CarType { get; set; }

        /// <summary>
        /// Number of parking place
        /// </summary>
        public int NumberOfParkingPlace { get; set; }

        /// <summary>
        /// UsedCounter used for realizing Id property as autoincrement
        /// </summary>
        private static List<bool> UsedCounter = new List<bool>();

        private static object Lock = new object();

        public Car()
        {

        }

        public void Dispose()
        {
            lock (Lock)
            {
                UsedCounter[Id] = false;
            }
        }

        /// <summary>
        /// Get available index for Id property
        /// </summary>
        /// <returns>Available Id for instance of car</returns>
        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            // Nothing available.
            return -1;
        }

        /// <summary>
        /// Set Id of car
        /// </summary>
        private void SetIdOfCar()
        {
            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }

                Id = nextIndex;
            }
        }
    }
}
