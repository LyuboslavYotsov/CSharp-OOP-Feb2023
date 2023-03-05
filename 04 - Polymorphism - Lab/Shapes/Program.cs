using System;

namespace Shapes;

public class StartUp
{
    static void Main(string[] args)
    {
        Shape circle = new Circle(4);
        Shape rectangle = new Rectangle(4, 5);

        var test = circle as Circle;
        Console.WriteLine(test.CalculatePerimeter());
        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(rectangle.CalculatePerimeter());
        Console.WriteLine(circle.CalculateArea());
        Console.WriteLine(rectangle.CalculateArea());

        Console.WriteLine(circle.Draw());
        Console.WriteLine(rectangle.Draw());
        Console.WriteLine(test.Draw());
    }
}