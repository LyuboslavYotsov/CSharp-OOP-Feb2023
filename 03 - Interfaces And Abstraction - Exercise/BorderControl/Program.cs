using System;
using System.Collections.Generic;

namespace BorderControl;
public class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> unitsList = new List<IIdentifiable>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commArgs = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (commArgs.Length == 3)
            {
                IIdentifiable currentCitizen = new Citizen(commArgs[0], int.Parse(commArgs[1]), commArgs[2]);
                unitsList.Add(currentCitizen);
            }
            else if (commArgs.Length == 2)
            {
                IIdentifiable currentRobot = new Robot(commArgs[0], commArgs[1]);
                unitsList.Add(currentRobot);
            }
        }

        int fakeInfo = int.Parse(Console.ReadLine());

        foreach (var unit in unitsList)
        {
            if (unit.Id.EndsWith(fakeInfo.ToString()))
            {
                Console.WriteLine(unit.Id);
            }
        }
    }
}