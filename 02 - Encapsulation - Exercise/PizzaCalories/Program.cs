using PizzaCalories.Models;
using System;


string[] pizzaInfo = Console.ReadLine()
    .Split(" ");
Pizza pizza;
try
{
    pizza = new(pizzaInfo[1]);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

string command;
while ((command = Console.ReadLine()) != "END")
{
    string[] commArgs = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string ingredient = commArgs[0];

    try
    {
        if (ingredient == "Dough")
        {
            Dough dough = new(commArgs[1], commArgs[2], int.Parse(commArgs[3]));

            pizza.Dough = dough;
        }
        else if (ingredient == "Topping")
        {
            Topping topping = new(commArgs[1], double.Parse(commArgs[2]));
            pizza.AddToping(topping);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

Console.WriteLine(pizza);