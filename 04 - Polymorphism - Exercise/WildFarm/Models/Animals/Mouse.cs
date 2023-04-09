using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MouseweightMultiplayer = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferedFoods
            => new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

        public override double WeightMultiplayer => MouseweightMultiplayer;

        public override string ProduceSound() => "Squeak";
    }
}
