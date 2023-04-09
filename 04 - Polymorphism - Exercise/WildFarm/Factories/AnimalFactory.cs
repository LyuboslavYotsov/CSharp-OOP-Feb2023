using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalInfo)
        {
            IAnimal animal = null;
            string animalType = animalInfo[0];
            string animalName = animalInfo[1];
            double animalWeight = double.Parse(animalInfo[2]);

            if (animalType == "Owl")
            {
                animal = new Owl(animalName, animalWeight, double.Parse(animalInfo[3]));
            }
            else if (animalType == "Hen")
            {
                animal = new Hen(animalName, animalWeight, double.Parse(animalInfo[3]));
            }
            else if (animalType == "Mouse")
            {
                animal = new Mouse(animalName, animalWeight, animalInfo[3]);
            }
            else if (animalType == "Dog")
            {
                animal = new Dog(animalName, animalWeight, animalInfo[3]);
            }
            else if (animalType == "Cat")
            {
                animal = new Cat(animalName, animalWeight, animalInfo[3], animalInfo[4]);
            }
            else if (animalType == "Tiger")
            {
                animal = new Tiger(animalName, animalWeight, animalInfo[3], animalInfo[4]);
            }


            return animal;
        }
    }
}
