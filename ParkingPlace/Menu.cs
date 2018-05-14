using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    public class Menu
    {
        /// <summary>
        /// Instance of Menu class. Pattern Singleton
        /// </summary>
        private static readonly Menu menu = new Menu();

        /// <summary>
        /// Parking
        /// </summary>
        public Parking Parking { get; private set; }

        private Menu()
        {
            Parking = Parking.GetParking();


        }

        public static Menu GetMenu()
        {
            return menu;
        }
    }
}
