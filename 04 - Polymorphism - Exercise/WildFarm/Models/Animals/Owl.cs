using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeightMultiplayer = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferedFoods
            => new HashSet<Type> { typeof(Meat) };

        public override double WeightMultiplayer => OwlWeightMultiplayer;

        public override string ProduceSound() => "Hoot Hoot";
    }
}
