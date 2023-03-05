using System;
using System.Collections.Generic;

namespace BirthdayCelebrations;
public class StartUp
{
    static void Main(string[] args)
    {
        List<IBirthable> birthable = new List<IBirthable>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commArgs = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (commArgs[0] == "Citizen")
            {
                IBirthable citizen = new Citizen(commArgs[1], int.Parse(commArgs[2]), commArgs[3], commArgs[4]);
                birthable.Add(citizen);
            }
            else if (commArgs[0] == "Pet")
            {
                IBirthable pet = new Pet(commArgs[1], commArgs[2]);
                birthable.Add(pet);
            }
            
        }

        int year = int.Parse(Console.ReadLine());

        foreach (var unit in birthable)
        {
            if (unit.Birthdate.EndsWith(year.ToString()))
            {
                Console.WriteLine(unit.Birthdate);
            }
        }
    }
}