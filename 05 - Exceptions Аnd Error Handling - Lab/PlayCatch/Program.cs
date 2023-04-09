using System;
using System.Linq;

int[] numbers = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

int exceptionCount = 0;

while (exceptionCount < 3)
{
    string[] commandArgs = Console.ReadLine()
        .Split(" ");

    string command = commandArgs[0];

    try
    {
        switch (command)
        {
            case "Replace":
                Replace(commandArgs);
                break;
            case "Print":
                Print(commandArgs);
                break;
            case "Show":
                Show(commandArgs);
                break;
        }
    }
    catch (IndexOutOfRangeException indexEx)
    {
        Console.WriteLine(indexEx.Message);
        exceptionCount++;
    }
    catch(FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        exceptionCount++;
    }
}
Console.WriteLine(string.Join(", ",numbers));

void Show(string[] commandArgs)
{
    int index = int.Parse(commandArgs[1]);
    ValidateIndex(index);
    Console.WriteLine(numbers[index]);
}

void Print(string[] commandArgs)
{
    int startIndex = int.Parse(commandArgs[1]);
    int endIndex = int.Parse(commandArgs[2]);
    ValidateIndex(startIndex);
    ValidateIndex(endIndex);
    int[] numbersInRange = numbers[startIndex..(endIndex + 1)];
    Console.WriteLine(string.Join(", ",numbersInRange));
}

void Replace(string[] commandArgs)
{
    int index = int.Parse(commandArgs[1]);
    int element = int.Parse(commandArgs[2]);
    ValidateIndex(index);

    numbers[index] = element;
}

bool ValidateIndex(int index)
{
    if (index < 0 || index >= numbers.Length)
    {
        throw new IndexOutOfRangeException("The index does not exist!");
    }
    return true;
}