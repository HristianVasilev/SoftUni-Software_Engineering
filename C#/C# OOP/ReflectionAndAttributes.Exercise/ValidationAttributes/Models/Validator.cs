namespace ValidationAttributes.Models
{
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Models.Attributes;


    static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(MyValidationAttribute), false);

                foreach (var customAttribute in customAttributes)
                {
                    MyValidationAttribute myValidationAttribute = (MyValidationAttribute)customAttribute;
                    bool isValid = myValidationAttribute.IsValid(propertyInfo.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
