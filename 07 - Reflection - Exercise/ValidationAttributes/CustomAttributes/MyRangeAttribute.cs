using System;


namespace ValidationAttributes.CustomAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public string ProperetyInfo { get; private set; }

        public override bool IsValid(object obj)
           => (int)obj > minValue && (int)obj < maxValue;
    }
}
