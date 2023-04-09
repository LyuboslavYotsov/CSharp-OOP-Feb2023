using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract IReadOnlyCollection<Type> PreferedFoods { get; }

        public abstract double WeightMultiplayer { get; }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public void Eat(IFood food)
        {
            if (!PreferedFoods.Any(pf => pf.Name == food.GetType().Name))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += food.Quantity * WeightMultiplayer;
                FoodEaten += food.Quantity;
            }
        }

        public abstract string ProduceSound();
    }
}
