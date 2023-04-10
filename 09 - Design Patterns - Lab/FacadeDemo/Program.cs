using FacadeDemo.Models;
using FacadeDemo.Models.Facades;
using System;

namespace FacadeDemo;

public class StartUp
{
    static void Main(string[] args)
    {
        var car = new CarBuilderFacade()
            .Info
            .WithType("BMW")
            .WithColor("Black")
            .WithNumberOfDoors(5)
            .Built
            .InCity("Leipzig")
            .AtAddress("Some adress")
            .Build();

        Console.WriteLine(car);
    }
}