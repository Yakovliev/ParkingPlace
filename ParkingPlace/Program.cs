using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParkingPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test
            //Test
            //Parking parking = Parking.GetParking();

            //parking.AddCar(CarTypes.Bus);
            //parking.AddCar(CarTypes.Motorcycle, 10);
            //parking.AddCar(CarTypes.Passenger, 0);

            //parking.DeleteCarByNumberOfParkingPlace(1);
            //parking.AddCar(CarTypes.Truck);
            //parking.AddCar(CarTypes.Passenger, 20);

            //parking.DeleteCarById(2);
            //parking.AddCar(CarTypes.Bus, 20);

            ////parking.AddCar(CarTypes.Motorcycle, -2);

            //parking.ReplenishCarBalanceById(0, 25);

            //int free = parking.GetFreeParkingPlaces();
            //int occupied = parking.GetOccupiedParkingPlaces();

            //parking.AddCar(CarTypes.Bus);

            //parking.WriteOffFunds();
            //parking.WriteOffFunds();

            //StringBuilder stringBuilder = parking.GetTransactionsForLastMinute();

            //Console.WriteLine(stringBuilder.ToString());

            //Console.ReadKey();

            //double earnedFundsForLastMinute = parking.GetEarnedFundsForLastMinute();

            //double balanceOfParking = parking.Balance;

            //parking.WriteAtTransactionLog();
            //parking.WriteAtTransactionLog();

            //string dateFromTransactionLog = parking.ReadTransactionLog();

            //Console.WriteLine(dateFromTransactionLog);

            //Console.ReadKey();

            #endregion

            Menu menu = Menu.GetMenu();

            menu.AddCar(CarTypes.Bus, 20);
            menu.AddCar(CarTypes.Truck);
            menu.AddCar(CarTypes.Passenger, 10);

            Thread.Sleep(10 * 1000);
            menu.DeleteCarById(1);

            menu.GetEarnedFundsForLastMinute();

            Thread.Sleep(60 * 1000);
            menu.GetTransactionsForLastMinute();

            menu.GetEarnedFundsForLastMinute();

            Thread.Sleep(60 * 1000);
            menu.GetTransactionsForLastMinute();

            Thread.Sleep(10 * 1000);
            Console.WriteLine("______");
            menu.ReadTransactionLog();
        }
    }
}
