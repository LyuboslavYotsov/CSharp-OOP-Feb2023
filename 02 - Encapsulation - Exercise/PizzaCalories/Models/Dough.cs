using System;
using System.Collections.Generic;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> flourTypeCalories;
        private readonly Dictionary<string, double> bakingTechniqueCalories;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            flourTypeCalories = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
            bakingTechniqueCalories = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            Weight = weight;
            BakingTechnique = bakingTechnique;
            FlourType = flourType;
        }

        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }


        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }


        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeModifier = flourTypeCalories[flourType.ToLower()];
                double bakingTechniqueModifier = bakingTechniqueCalories[bakingTechnique.ToLower()];

                return weight * BaseCaloriesPerGram * flourTypeModifier * bakingTechniqueModifier;
            }
        }
    }
}
