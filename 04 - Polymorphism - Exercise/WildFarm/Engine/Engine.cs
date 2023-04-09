

using System;
using System.Collections.Generic;
using WildFarm.Factories;
using WildFarm.IO;
using WildFarm.Models.Interfaces;

namespace WildFarm.Engine
{
    public class Engine : IEngine
    {
        private IFoodFactory foodFactory;
        private IAnimalFactory animalFactory;
        private IWriter writer;
        private IReader reader;
        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            foodFactory= new FoodFactory();
            animalFactory= new AnimalFactory();
        }
        public void Run()
        {
            List<IAnimal> animals = new List<IAnimal>();

            string input = string.Empty;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] animalInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IAnimal animal = animalFactory.CreateAnimal(animalInfo);
                IFood food = foodFactory.CreateFood(foodInfo);

                writer.WriteLine(animal.ProduceSound());
                animal.Eat(food);

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal);
            }
        }
    }
}
