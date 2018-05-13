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
                FreeParkingPlacesList[numberOfFreeParkingPlace] = false;
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
                FreeParkingPlacesList[numberOfFreeParkingPlace] = false;

            }
            else
            {
                throw new NoFreeParkingPlacesException("No free parking places!");
            }
        }

        /// <summary>
        /// Delete a car by number of parking place.
        /// </summary>
        /// <param name="numberOfParkingPlace">Number of parking place where is located the car which user wants to delete.</param>
        public void DeleteCarByNumberOfParkingPlace(int numberOfParkingPlace)
        {
            //numberOfParkingPlace = 0, 1, 2, ..., Settings.ParkingSpace - 1
            if (numberOfParkingPlace > Settings.ParkingSpace - 1)
            {
                throw new NumberOfParkingPlaceDoesNotExistException("Number of parking place does not exist!");
            }

            if (FreeParkingPlacesList[numberOfParkingPlace])
            {
                throw new ParkingPlaceIsFreeException("We can`t delete a car! Parking place is already free!");
            }

            int counterOfDeleteCar = 0;

            foreach (Car item in ListOfCars)
            {
                if (item.NumberOfParkingPlace != numberOfParkingPlace)
                {
                    counterOfDeleteCar++;
                }
                else
                {
                    break;
                }
            }

            if (ListOfCars[counterOfDeleteCar].Balance < 0)
            {
                throw new CarBalanceLessZeroException("You can`t delete the car. Balance less zero!");
            }

            //Можна доробити, щоб при видаленні машини спрацьовував метод Dispose() класу Car. Тоді будуть вивільнятися id видалених
            //і вони будуть використані для створення нових машин.
            ListOfCars.RemoveAt(counterOfDeleteCar);
            FreeParkingPlacesList[numberOfParkingPlace] = true;
        }

        /// <summary>
        /// Delete a car by id.
        /// </summary>
        /// <param name="idOfCar">Id of car.</param>
        public void DeleteCarById(int idOfCar)
        {
            int counterOfId = 0;

            foreach (Car item in ListOfCars)
            {
                if (item.Id == idOfCar)
                {
                    break;
                }
                else
                {
                    counterOfId++;
                }
            }

            if (counterOfId >= ListOfCars.Count)
            {
                throw new IdOfCarDoesNotExistException("Id of car does not exist!");
            }

            if (ListOfCars[counterOfId].Balance < 0)
            {
                throw new CarBalanceLessZeroException("You can`t delete the car. Balance less zero!");
            }

            FreeParkingPlacesList[ListOfCars[counterOfId].NumberOfParkingPlace] = true;
            ListOfCars.RemoveAt(counterOfId);
        }

        /// <summary>
        /// Replenish balance of car by id.
        /// </summary>
        /// <param name="idOfCar">Id of car</param>
        /// <param name="amount">Amount of money</param>
        public void ReplenishCarBalanceById(int idOfCar, double amount)
        {
            if (amount <= 0)
            {
                throw new AmountOfMoneyLessZeroException("Amount of money less or equal zero!");
            }

            int counterOfId = 0;

            foreach (Car item in ListOfCars)
            {
                if (item.Id == idOfCar)
                {
                    break;
                }
                else
                {
                    counterOfId++;
                }
            }

            if (counterOfId >= ListOfCars.Count)
            {
                throw new IdOfCarDoesNotExistException("Id of car does not exist!");
            }

            ListOfCars[counterOfId].Balance += amount;
        }

        /// Get number of free parking places.
        /// </summary>
        /// <returns>Number of free parking places.</returns>
        public int GetFreeParkingPlaces()
        {
            int numberOfFreeParkingPlaces = 0;

            foreach (bool item in FreeParkingPlacesList)
            {
                if (item)
                {
                    numberOfFreeParkingPlaces++;
                }
            }

            return numberOfFreeParkingPlaces;
        }

        /// <summary>
        /// Get number of occupied parking places.
        /// </summary>
        /// <returns>Number of occupied parking places.</returns>
        public int GetOccupiedParkingPlaces()
        {
            int numberOfOccupiedParkingPlaces = 0;

            foreach (bool item in FreeParkingPlacesList)
            {
                if (!item)
                {
                    numberOfOccupiedParkingPlaces++;
                }
            }

            return numberOfOccupiedParkingPlaces;
        }
    }
}
