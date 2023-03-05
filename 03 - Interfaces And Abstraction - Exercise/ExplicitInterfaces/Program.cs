using System;

namespace ExplicitInterfaces;

public class StartUp
{
    static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IPerson person = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
            IResident resident = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());
        }
    }
}