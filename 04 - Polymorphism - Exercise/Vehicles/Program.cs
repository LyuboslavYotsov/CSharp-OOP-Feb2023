using System;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string[] truckInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string[] busInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];
            string vehicleType = tokens[1];
            double value = double.Parse(tokens[2]);

            if (command == "Drive")
            {
                if (vehicleType == "Car")
                {
                    car.Drive(value);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Drive(value);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Drive(value);
                }
            }
            else if (command == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(value);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(value);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(value);
                }
            }
            else if (command == "DriveEmpty")
            {
                if (vehicleType == "Bus")
                {
                    bus.DriveEmpty(value);
                }
            }
        }
        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }
}