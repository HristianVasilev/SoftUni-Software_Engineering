namespace ValidationAttributes.Models.Attributes
{
    using System;

    abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);

    }
}
