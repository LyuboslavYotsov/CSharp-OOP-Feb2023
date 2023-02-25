namespace Zoo
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal animal = new Animal("Jivotno");
            Reptile reptile = new Reptile("Vlechugo");
            Mammal mammal = new Mammal("Bozainik");
            Bear bear = new Bear("Mechka");
            Gorilla gorilla = new Gorilla("Gorila");
            Lizard lizard = new Lizard("Gushter");
            Snake snek = new Snake("Zmiiy");


            Console.WriteLine(animal.Name);
            Console.WriteLine(reptile.Name);
            Console.WriteLine(mammal.Name);
            Console.WriteLine(bear.Name);
            Console.WriteLine(gorilla.Name);
            Console.WriteLine(lizard.Name);
            Console.WriteLine(snek.Name);
        }
    }
}