using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {

		private string name;
		private decimal money;
		private List<Product> products;

        public Person(string name, decimal money)
        {
            Money = money;
            Name = name;
			products= new List<Product>();
        }

        public IReadOnlyCollection<Product> Products
		{
			get { return products.AsReadOnly(); }
		}



		public decimal Money
		{
			get { return money; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
                money = value;
            }
		}


		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}
                name = value;
            }
		}

		public void Buy(Product product)
		{
			if (this.Money >= product.Cost)
			{
				products.Add(product);
				this.Money -= product.Cost;
				Console.WriteLine($"{Name} bought {product.Name}");
			}
			else
			{
				Console.WriteLine($"{this.Name} can't afford {product.Name}");
			}
		}
	}
}
