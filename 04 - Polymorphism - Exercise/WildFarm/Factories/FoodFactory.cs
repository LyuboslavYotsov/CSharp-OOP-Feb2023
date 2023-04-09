using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] foodInfo)
        {
            IFood food = null;
            string foodType = foodInfo[0];
            int foodQantity = int.Parse(foodInfo[1]);

            if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(foodQantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQantity);
            }


            return food;
        }
    }
}
