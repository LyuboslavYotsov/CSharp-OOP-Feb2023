using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeExample
{
    public class Sandwitch : SandwitchPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwitch(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;

        }

        public override SandwitchPrototype Clone()
        {
            string ingredientsList = GetIngredientsList();

            Console.WriteLine($"Cloning sandwitch with ingredients: {ingredientsList}");

            return MemberwiseClone() as SandwitchPrototype;
        }

        private string GetIngredientsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
