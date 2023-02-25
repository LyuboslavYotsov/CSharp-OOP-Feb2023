namespace Animals
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string type;

            while ((type = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];
                try
                {
                    if (type == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        PrintAnimal(dog);
                    }
                    else if (type == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        PrintAnimal(cat);
                    }
                    else if (type == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        PrintAnimal(frog);
                    }
                    else if (type == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        PrintAnimal(kitten);
                    }
                    else if (type == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        PrintAnimal(tomcat);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

            }

            void PrintAnimal<T>(T animal) where T : Animal
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
