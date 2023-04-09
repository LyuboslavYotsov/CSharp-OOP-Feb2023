﻿
using System;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        const double AirConditionerFuelConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double kilometers)
        {
            double fuelNeeded = kilometers * (FuelConsumption + AirConditionerFuelConsumption);
            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"Truck travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
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
                liters = liters * 0.95;
                FuelQuantity += liters;
            }
        }
    }
}
