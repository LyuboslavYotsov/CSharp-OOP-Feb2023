using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplayer = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferedFoods
             => new HashSet<Type> { typeof(Meat) };

        public override double WeightMultiplayer => DogWeightMultiplayer;

        public override string ProduceSound() => "Woof!";
    }
}
