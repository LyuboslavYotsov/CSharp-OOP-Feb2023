namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double TankCapacity { get; }

        double FuelQuantity { get; }

        double FuelConsumption { get; }

        void Drive(double kilometers);

        void Refuel(double liters);
    }
}
