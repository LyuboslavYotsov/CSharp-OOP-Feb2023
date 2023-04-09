using System;

string[] elements = Console.ReadLine()
    .Split(" ");

int integerSum = 0;

foreach (string element in elements)
{
    ProcessElement(element);
}
Console.WriteLine($"The total sum of all integers is: {integerSum}");

void ProcessElement(string element)
{
    int number = 0;
	try
	{
		number = int.Parse(element);
	}
	catch (FormatException)
	{
		Console.WriteLine($"The element '{element}' is in wrong format!");
	}
	catch (OverflowException)
	{
		Console.WriteLine($"The element '{element}' is out of range!");
	}
	finally
	{
		integerSum+= number;
		Console.WriteLine($"Element '{element}' processed - current sum: {integerSum}");
	}
}