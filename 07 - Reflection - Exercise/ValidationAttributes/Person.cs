using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes
{
    public class Person
    {
        private const int minValue = 12;
        private const int maxValue = 90;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
        [MyRequired]
        public string FullName { get; private set; }
        [MyRange(minValue, maxValue)]
        public int Age { get; private set; }
    }
}
