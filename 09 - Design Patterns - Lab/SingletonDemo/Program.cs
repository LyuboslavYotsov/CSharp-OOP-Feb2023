using SingletonDemo.Models;
using SingletonDemo.Models.Interfaces;
using System;

namespace SingletonDemo;

public class StartUp
{
    static void Main(string[] args)
    {
        ISingletonContainer sdc = SingletonDataContainer.Instance;
        ISingletonContainer sdc2 = SingletonDataContainer.Instance;
        ISingletonContainer sdc3 = SingletonDataContainer.Instance;
        ISingletonContainer sdc4 = SingletonDataContainer.Instance;



        Console.WriteLine(sdc.GetPopulation("London"));
        Console.WriteLine(sdc4.GetPopulation("Washington, D.C."));
    }
}