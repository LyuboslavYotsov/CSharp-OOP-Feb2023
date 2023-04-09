
using System;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        const double AirConditionerFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double kilometers)
        {
            double fuelNeeded = kilometers * (FuelConsumption + AirConditionerFuelConsumption);
            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"Bus travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double kilometers)
        {
            double fuelNeeded = kilometers * FuelConsumption;
            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"Bus travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters;
            }
        }
    }
}
