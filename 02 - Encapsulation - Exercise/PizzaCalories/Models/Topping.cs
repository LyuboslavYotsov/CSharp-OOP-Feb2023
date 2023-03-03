using System;
using System.Collections.Generic;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> TypeCalories;

        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            TypeCalories = new Dictionary<string, double> { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (!TypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }


        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double typeModifier = TypeCalories[Type.ToLower()];
                return Weight * typeModifier * BaseCaloriesPerGram;
            }
        }
    }
}
