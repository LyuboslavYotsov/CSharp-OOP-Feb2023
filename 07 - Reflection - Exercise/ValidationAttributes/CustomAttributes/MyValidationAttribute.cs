

using System;

namespace ValidationAttributes.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
