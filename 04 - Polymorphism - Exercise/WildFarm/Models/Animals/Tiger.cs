using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    internal class Tiger : Feline
    {
        private const double TigerWeightMultiplayer = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferedFoods
             => new HashSet<Type> { typeof(Meat) };

        public override double WeightMultiplayer => TigerWeightMultiplayer;

        public override string ProduceSound() => "ROAR!!!";
    }
}
