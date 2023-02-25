using System;

namespace Animals
{
    public abstract class Animal
    {

        private string name;
        private int age;
        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }


        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

       
        
        public override string ToString()
        {
            return $"{this.GetType().Name}{Environment.NewLine}{Name} {Age} {Gender}";
        }

        public abstract string ProduceSound();
    }
}
