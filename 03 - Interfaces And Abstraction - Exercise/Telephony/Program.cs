using System;
using Telephony;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] sites = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var number in numbers)
        {
            if (number.Length == 7)
            {
                ICallable stationaryPhone = new StationayPhone();
                Console.WriteLine(stationaryPhone.Call(number));
            }
            else if (number.Length == 10)
            {
                ICallable smarhPhone = new Smartphone();
                Console.WriteLine(smarhPhone.Call(number));
            }
        }

        foreach (var site in sites)
        {
            IBrowsable smartPhone = new Smartphone();
            Console.WriteLine(smartPhone.Browse(site));
        }
    }
}