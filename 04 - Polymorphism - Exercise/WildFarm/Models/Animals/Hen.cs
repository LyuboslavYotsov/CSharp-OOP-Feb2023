using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplayer = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferedFoods 
            => new HashSet<Type> { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof (Seeds)};

        public override double WeightMultiplayer => HenWeightMultiplayer;

        public override string ProduceSound() => "Cluck";
    }
}
