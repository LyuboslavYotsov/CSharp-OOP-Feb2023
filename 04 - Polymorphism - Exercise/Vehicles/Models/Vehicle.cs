using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if(value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public abstract void Drive(double kilometers);

        public abstract void Refuel(double liters);
    }
}
