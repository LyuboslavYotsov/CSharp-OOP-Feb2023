using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties =
                type.GetProperties()
                .Where(p => p.CustomAttributes
                    .Any(ca => typeof(MyValidationAttribute)
                        .IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> atributes = property
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (var atribute in atributes)
                {
                    if (!atribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
