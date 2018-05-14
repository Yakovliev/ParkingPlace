using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test
            Parking parking = Parking.GetParking();

            parking.AddCar(CarTypes.Bus);
            parking.AddCar(CarTypes.Motorcycle, 10);
            parking.AddCar(CarTypes.Passenger, 0);

            parking.DeleteCarByNumberOfParkingPlace(1);
            parking.AddCar(CarTypes.Truck);
            parking.AddCar(CarTypes.Passenger, 20);

            parking.DeleteCarById(2);
            parking.AddCar(CarTypes.Bus, 20);

            //parking.AddCar(CarTypes.Motorcycle, -2);

            parking.ReplenishCarBalanceById(0, 25);

            int free = parking.GetFreeParkingPlaces();
            int occupied = parking.GetOccupiedParkingPlaces();

            parking.AddCar(CarTypes.Bus);

            parking.WriteOffFunds();
            parking.WriteOffFunds();

            StringBuilder stringBuilder = parking.GetTransactionsForLastMinute();

            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();

            double earnedFundsForLastMinute = parking.GetEarnedFundsForLastMinute();

        }
    }
}
