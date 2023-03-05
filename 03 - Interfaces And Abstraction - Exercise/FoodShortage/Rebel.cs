
namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Group { get; set; }
        public string Name { get; private set; }

        public int Age {get; private set;}

        public int Food { get; private set;}

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
