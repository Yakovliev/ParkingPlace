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
        public List<Car> ListOfCars { get; private set; } = new List<Car>();

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

        /// <summary>
        /// Settings of parking
        /// </summary>
        public Settings Settings { get; private set; }

        /// <summary>
        /// Free parking places list
        /// </summary>
        private static List<bool> FreeParkingPlacesList;

        private Parking()
        {
            Settings = Settings.GetSettings();

            FreeParkingPlacesList = new List<bool>();

            //All parking places are free when parking initializing
            for (int i = 0; i < Settings.ParkingSpace; i++)
            {
                FreeParkingPlacesList.Add(true);
            }
        }

        public static Parking GetParking()
        {
            return parking;
        }

        /// <summary>
        /// If method return true than there is free parking place, 
        /// if meghod return false than there are no free parking places.
        /// </summary>
        /// <returns>If method return true than there is free parking place.</returns>
        private bool IsThereFreeParkingPlace()
        {
            bool freeParkingPlace = false;

            foreach (bool item in FreeParkingPlacesList)
            {
                if (item == true)
                {
                    freeParkingPlace = true;
                    break;
                }
            }

            return freeParkingPlace;
        }

        /// <summary>
        /// Add car on parking WITHOUT starting balance.
        /// </summary>
        /// <param name="carType">Type of car</param>
        public void AddCar(CarTypes carType)
        {
            bool freeParkingPlace = IsThereFreeParkingPlace();

            int numberOfFreeParkingPlace = 0;

            if (freeParkingPlace)
            {
                for (int i = 0; i < FreeParkingPlacesList.Count; i++)
                {
                    if (FreeParkingPlacesList[i] == true)
                    {
                        numberOfFreeParkingPlace = i;
                        break;
                    }
                }

                ListOfCars.Add(new Car(carType, numberOfFreeParkingPlace));
            }
            else
            {
                throw new NoFreeParkingPlacesException("No free parking places!");
            }
        }

        /// <summary>
        /// Add car on parking WITH starting balance.
        /// </summary>
        /// <param name="carType">Type of car</param>
        /// <param name="defaultBalance">Starting balance of car</param>
        public void AddCar(CarTypes carType, double defaultBalance)
        {
            bool freeParkingPlace = IsThereFreeParkingPlace();

            int numberOfFreeParkingPlace = 0;

            if (freeParkingPlace)
            {
                for (int i = 0; i < FreeParkingPlacesList.Count; i++)
                {
                    if (FreeParkingPlacesList[i] == true)
                    {
                        numberOfFreeParkingPlace = i;
                        break;
                    }
                }

                ListOfCars.Add(new Car(carType, numberOfFreeParkingPlace, defaultBalance));
            }
            else
            {
                throw new NoFreeParkingPlacesException("No free parking places!");
            }
        }
    }
}
