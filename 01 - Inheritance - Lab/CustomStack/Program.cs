using System;
using System.Collections.Generic;

namespace CustomStack;

public class StartUp
{
    static void Main(string[] args)
    {
        StackOfStrings myStack = new StackOfStrings();

        Console.WriteLine(myStack.IsEmpty());
        List<string> myList = new List<string>()
        {
            "asd",
            "dfd",
            "d",
            "g",
            "c",
            "o",
            "B",
            "u",
            "B",
        };
        myStack.AddRange(myList);

        foreach (var item in myStack)
        {
            Console.WriteLine(item);
        }
    }
}