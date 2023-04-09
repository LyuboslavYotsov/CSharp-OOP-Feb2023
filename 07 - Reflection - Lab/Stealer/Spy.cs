using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields((BindingFlags)60);
            Object classInstance = Activator.CreateInstance(classType);
            sb.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in classFields.Where(f => fieldNames.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} - {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            

            FieldInfo[] classFields = classType.GetFields((BindingFlags)60);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in classFields)
            {
                if (field.IsPublic)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var nonPublicMethod in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
            }

            foreach (var publicMethod in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new();
            Type classType = Type.GetType(className);

            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }


            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);

            MethodInfo[] classMethods = classType.GetMethods((BindingFlags)60);

            foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType.FullName}");
            }
            foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType.FullName}");
            }


            return sb.ToString().Trim();
        }
    }
}
