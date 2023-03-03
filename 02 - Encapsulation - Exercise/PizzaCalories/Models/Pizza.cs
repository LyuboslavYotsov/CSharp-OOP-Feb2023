using System;
using System.Collections.Generic;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            toppings = new List<Topping>();
            Name = name;
        }

        public Dough Dough
        {
            set
            {
                dough = value;
            }
        }
        public int ToppingsCount => toppings.Count;

        public double TotalCalories
        {
            get
            {
                double toppingCalories = 0;
                foreach (var topping in toppings)
                {
                    toppingCalories += topping.Calories;
                }

                return toppingCalories + dough.Calories;
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public void AddToping(Topping topping)
        {
            if (ToppingsCount == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
