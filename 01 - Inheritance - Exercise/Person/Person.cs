using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
		private string name;
		private int age;

        public Person(string name, int age)
        {
            this.age = age;
            this.name = name;
        }

        public int Age
		{
			get { return age; }
			set 
            {
                if (value >= 0)
                {
                    this.age = value;
                }
            }
		}


		public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

    }
}
