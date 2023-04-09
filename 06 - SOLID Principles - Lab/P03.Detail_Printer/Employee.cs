using System;

namespace P03.Detail_Printer
{
    public class Employee : IDeatails
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void PrintDetails()
        {
            Console.WriteLine(Name);
        }
    }
}
