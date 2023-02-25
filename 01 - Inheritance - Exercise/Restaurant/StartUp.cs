namespace Restaurant
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Fish fish = new("Riba", 10m);
            Console.WriteLine(fish.Grams);
        }
    }
}