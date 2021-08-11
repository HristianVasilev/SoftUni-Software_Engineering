namespace ValidationAttributes.Models.Attributes
{
    using System;


    class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("The object is not an integer!");
            }

            int valueAsInt = (int)obj;

            bool isInRange = valueAsInt >= minValue && valueAsInt <= maxValue;

            return isInRange;
        }
    }
}
