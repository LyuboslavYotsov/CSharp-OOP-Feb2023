using System;
using System.Collections.Generic;

int start = 1;
int end = 100;
int lastNumber = 1;
List<int> numbersInRage = new List<int>();
while (numbersInRage.Count < 10)
{
    numbersInRage.Add(ReadNumber(start, end));
}

Console.WriteLine(string.Join(", ",numbersInRage));



int ReadNumber(int start, int end)
{
    int number = 0;
    while (number == 0)
    {
        try
        {
            int inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber <= lastNumber || inputNumber >= end)
            {
                throw new ArgumentException($"Your number is not in range {lastNumber} - {end}!");
            }
            number = inputNumber;
            lastNumber= number;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid Number!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return number;
}