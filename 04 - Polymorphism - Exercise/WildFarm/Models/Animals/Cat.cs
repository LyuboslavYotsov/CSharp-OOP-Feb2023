using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplayer = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferedFoods
             => new HashSet<Type> { typeof(Vegetable), typeof(Meat) };

        public override double WeightMultiplayer => CatWeightMultiplayer;

        public override string ProduceSound() => "Meow";
    }
}
