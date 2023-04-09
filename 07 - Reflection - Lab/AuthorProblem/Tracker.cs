

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            MethodInfo[] methods = classType.GetMethods((BindingFlags)60);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var atributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in atributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
