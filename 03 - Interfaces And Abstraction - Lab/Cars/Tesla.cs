
using System;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }

        public int Battery { get; }

        public string Model { get; }

        public string Color { get; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} Tesla Model {Model} with {Battery} Batteries{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
        }
    }
}
