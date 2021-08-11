namespace ValidationAttributes.Models.Attributes
{


    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null || !(obj is string))
            {
                return false;
            }

            string objAsString = (string)obj;

            return !string.IsNullOrEmpty(objAsString);
        }
    }
}
