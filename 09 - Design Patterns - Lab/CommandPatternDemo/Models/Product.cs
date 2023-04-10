using System;   

namespace CommandPatternDemo.Models
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public void IncreasePrice(decimal amount)
        {
            Price += amount;
            Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
        }

        public void DecreasePrice(decimal amount)
        {
            Price -= amount;
            Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
        }

        public override string ToString() => $"Current price for the {Name} product is {Price}$.";
    }
}
