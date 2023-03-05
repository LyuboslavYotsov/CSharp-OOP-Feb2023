using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage;

public class StartUp
{
    static void Main(string[] args)
    {
        int buyersCOunt = int.Parse(Console.ReadLine());

        List<IBuyer> buyers = new List<IBuyer>();
        for (int i = 0; i < buyersCOunt; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 4)
            {
                IBuyer citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                buyers.Add(citizen);
            }
            else if (tokens.Length == 3)
            {
                IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                buyers.Add(rebel);
            }
        }

        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            foreach (var person in buyers)
            {
                if (person.Name == name)
                {
                    person.BuyFood();
                }
            }
        }

        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}