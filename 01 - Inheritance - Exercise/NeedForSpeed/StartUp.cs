namespace NeedForSpeed
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar r34 = new SportCar(200, 100);
            FamilyCar kombi = new FamilyCar(200, 100);
            r34.Drive(5);
            kombi.Drive(5);
            Console.WriteLine(r34.Fuel);
            Console.WriteLine(kombi.Fuel);
        }
    }
}
